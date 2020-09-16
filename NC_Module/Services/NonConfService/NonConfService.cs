using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NC_Module.Data;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.NonConfService
{
    public class NonConfService : INonConfService
    {
        
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<GetNonConfDto> serviceResponse = new ServiceResponse<GetNonConfDto>();


        public NonConfService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceResponse<List<GetNonConfDto>> GetAllNonConf()
        {
            ServiceResponse<List<GetNonConfDto>> serviceResponse = new ServiceResponse<List<GetNonConfDto>>()
            {
                Data = _context.nonConfs.Select(n => _mapper.Map<GetNonConfDto>(n)).ToList()
            };

            return serviceResponse;
            
        }

        public ServiceResponse<GetNonConfDto> GetNonConfById(int id)
        {

            NonConfIdValidator(id);

            try
            {
                NonConf nonConf = _context.nonConfs
                .Include(n => n.NonConfCorrActions)
                .ThenInclude(nc => nc.CorrAction)
                .FirstOrDefault(n => n.Id == id);

                serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Impossível processar a requisição. Exception: " + ex;
            }
            
            return serviceResponse;
        }

        public ServiceResponse<GetNonConfDto> AddNonConf(NonConf nonConf)
        {
            
            try
            {
                _context.nonConfs.Add(nonConf);
                _context.SaveChanges();

                nonConf = _context.nonConfs.OrderByDescending(n => n.Id).First();

                CodeGenerator(nonConf);
                _context.SaveChanges();

                serviceResponse.Message = "NC criada com sucesso.";
                serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);
            } 
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Não foi possível criar a nova NC. Exception: " + ex;
            }

            return serviceResponse;
        }

        public ServiceResponse<GetNonConfDto> EvaluateNonConf(UpdateNonConfDto updateNonConfDto)
        {

            NonConfIdValidator(updateNonConfDto.Id);

            NonConf nonConf = _context.nonConfs.FirstOrDefault(n => n.Id == updateNonConfDto.Id);

            NcIsOpen(nonConf);

            try
            {

                nonConf.Status = updateNonConfDto.Status;
                _context.nonConfs.Update(nonConf);
                _context.SaveChanges();
                serviceResponse.Message = "Esta NC foi encerrada.";

                if (nonConf.Status == 2)
                {
                    NonConf newNonConf = new NonConf
                    {
                        Description = nonConf.Description,
                        Version = nonConf.Version + 1
                    };

                    _context.nonConfs.Add(newNonConf);
                    _context.SaveChanges();
                    newNonConf = _context.nonConfs.OrderByDescending(n => n.Id).First();
                    CodeGenerator(newNonConf);
                    _context.SaveChanges();
                    serviceResponse.Message = "Esta NC foi encerrada. Uma nova versão desta NC foi criada com o Código: " + newNonConf.Code;
                }

                serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);
            } 
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

            
        }


        private ServiceResponse<GetNonConfDto> NonConfIdValidator(int id)
        {
            if (_context.nonConfs.Find(id) == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "A NC requisitada não existe.";
                return serviceResponse;
            }

            return serviceResponse;
        }

        private void CodeGenerator(NonConf nonConf)
        {
            nonConf.Code = nonConf.Date.Year.ToString()
                + ":0" + nonConf.Id.ToString()
                + ":0" + nonConf.Version.ToString();
        }

        private ServiceResponse<GetNonConfDto> NcIsOpen(NonConf nonConf)
        {
            if (nonConf.Status != 0)
            {
                serviceResponse.Message = "Esta NC já foi encerrada e não pode mais ser alterada.";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            return serviceResponse;

        }
         
        
    }
}
