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

            _context.corrActions.Add(_mapper.Map<CorrAction>(corrAction));
            _context.SaveChanges();

            serviceResponse.Data = _mapper.Map<CorrActionDto>(corrAction);
            serviceResponse.Message = "The CorrAction was succesfull save.";

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


            serviceResponse.Data = _mapper.Map<CorrActionDto>(_context.corrActions.FirstOrDefault(c => c.Id == id));

            return serviceResponse;
        }
    }
}
