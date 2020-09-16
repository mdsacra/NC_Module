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

        public CorrActionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ServiceResponse<CorrActionDto> AddCorrAction(CorrActionDto corrAction)
        {
            ServiceResponse<CorrActionDto> serviceResponse = new ServiceResponse<CorrActionDto>();

            try
            {
                _context.corrActions.Add(_mapper.Map<CorrAction>(corrAction));
                _context.SaveChanges();

                serviceResponse.Data = _mapper.Map<CorrActionDto>(corrAction);
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
            ServiceResponse<List<CorrActionDto>> serviceResponse = new ServiceResponse<List<CorrActionDto>>();

                serviceResponse.Data = _context.corrActions.Select(c => _mapper.Map<CorrActionDto>(c)).ToList();

            return serviceResponse;
        }

        public ServiceResponse<CorrActionDto> GetCorrActionById(int id)
        {
            ServiceResponse<CorrActionDto> serviceResponse = new ServiceResponse<CorrActionDto>();

            CorrAction corrAction = _context.corrActions.FirstOrDefault(c => c.Id == id);

            if (corrAction == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "A CorrAction não foi encontrada.";
                return serviceResponse;
            }

            try
            {
                serviceResponse.Data = _mapper.Map<CorrActionDto>(corrAction);
                
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Impossível processar a requisição. Exception: " + ex;
            }

            return serviceResponse;
        }
    }
}
