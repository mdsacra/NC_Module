using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NC_Module.BLL.NonConfBLL;
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
        public NonConfBLL nonConfBll = new NonConfBLL();

        public NonConfService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceResponse<List<GetNonConfDto>> GetAllNonConf()
        {
            ServiceResponse<List<GetNonConfDto>> serviceResponse = new ServiceResponse<List<GetNonConfDto>>();

            serviceResponse.Data = _context.nonConfs.Select(n => _mapper.Map<GetNonConfDto>(n)).ToList();

            return serviceResponse;
            
        }


        public ServiceResponse<GetNonConfDto> GetNonConfById(int id)
        {

            ServiceResponse<GetNonConfDto> serviceResponse = new ServiceResponse<GetNonConfDto>();

            NonConf nonConf = _context.nonConfs
                .Include(n => n.NonConfCorrActions)
                .ThenInclude(nc => nc.CorrAction)
                .FirstOrDefault(n => n.Id == id);

            serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);
            
            return serviceResponse;
        }

        public ServiceResponse<GetNonConfDto> AddNonConf(NonConf nonConf)
        {
            
            ServiceResponse<GetNonConfDto> serviceResponse = new ServiceResponse<GetNonConfDto>();
            
            _context.nonConfs.Add(nonConf);
            _context.SaveChanges();

            nonConf = _context.nonConfs.OrderByDescending(n => n.Id).First();

            nonConfBll.NcCodeGenerator(nonConf);
            _context.SaveChanges();

            serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);

            return serviceResponse;
        }

        public ServiceResponse<GetNonConfDto> EvaluateNonConf(UpdateNonConfDto updateNonConfDto)
        {
            ServiceResponse<GetNonConfDto> serviceResponse = new ServiceResponse<GetNonConfDto>();

            NonConf nonConf = _context.nonConfs.FirstOrDefault(n => n.Id == updateNonConfDto.Id);

            nonConf.Status = updateNonConfDto.Status;
            _context.nonConfs.Update(nonConf);
            _context.SaveChanges();
            serviceResponse.Message = "This Nonconformity was closed.";

            if(nonConf.Status == 2)
            {
                NonConf newNonConf = new NonConf
                {
                    Description = nonConf.Description,
                    Version = nonConf.Version + 1
                };
                
                _context.nonConfs.Add(newNonConf);
                _context.SaveChanges();
                newNonConf = _context.nonConfs.OrderByDescending(n => n.Id).First();
                nonConfBll.NcCodeGenerator(newNonConf);
                _context.SaveChanges();
                serviceResponse.Message = "This Nonconformity was closed. A new version of this Nonconformity was create with Code: " + newNonConf.Code;
            }

            serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);

            return serviceResponse;
        }

        
    }
}
