using AutoMapper;
using NC_Module.Data;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.CorrActionService
{
    public class CorrActionService : ICorrActionService
    {
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<CorrActionDto> serviceResponse = new ServiceResponse<CorrActionDto>();

        public CorrActionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ServiceResponse<CorrActionDto> AddCorrAction(CorrActionDto corrAction)
        {

            try
            {
                _context.corrActions.Add(_mapper.Map<CorrAction>(corrAction));
                _context.SaveChanges();

                serviceResponse.Data = _mapper.Map<CorrActionDto>(_context.corrActions.OrderByDescending(c => c.Id).First());
                serviceResponse.Message = "A Ação foi criada com sucesso!";
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Não foi possível criar a nova Ação. Exception: " + ex;
            }
            

            return serviceResponse;
        }

        public ServiceResponse<List<CorrActionDto>> GetAllCorrActions()
        {
            ServiceResponse<List<CorrActionDto>> serviceResponse = new ServiceResponse<List<CorrActionDto>>()
            {
                Data = _context.corrActions.Select(c => _mapper.Map<CorrActionDto>(c)).ToList()
            };

            return serviceResponse;
        }

        public ServiceResponse<CorrActionDto> GetCorrActionById(int id)
        {
            
            CorrActionIdValidator(id);

            try
            {
                serviceResponse.Data = _mapper.Map<CorrActionDto>(_context.corrActions.FirstOrDefault(c => c.Id == id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Impossível processar a requisição. Exception: " + ex;
            }

            return serviceResponse;
        }

        
        public ServiceResponse<CorrActionDto> CorrActionIdValidator(int id)
        {
            if (_context.corrActions.Find(id) == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "A Ação não foi encontrada.";
                return serviceResponse;
            }

            return serviceResponse;
        }
    }
}
