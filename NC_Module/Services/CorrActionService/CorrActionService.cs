using NC_Module.Data;
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

        public CorrActionService(DataContext context)
        {
            _context = context;
        }
        public ServiceResponse<CorrAction> AddCorrAction(CorrAction corrAction)
        {
            ServiceResponse<CorrAction> serviceResponse = new ServiceResponse<CorrAction>();

            _context.corrActions.Add(corrAction);

            serviceResponse.Data = corrAction;
            serviceResponse.Message = "The CorrAction was succesfull save.";

            return serviceResponse;
        }

        public ServiceResponse<List<CorrAction>> GetAllCorrActions()
        {
            ServiceResponse<List<CorrAction>> serviceResponse = new ServiceResponse<List<CorrAction>>();

            serviceResponse.Data = _context.corrActions.ToList();

            return serviceResponse;
        }

        public ServiceResponse<CorrAction> GetCorrActionById(int id)
        {
            ServiceResponse<CorrAction> serviceResponse = new ServiceResponse<CorrAction>();

            serviceResponse.Data = _context.corrActions.FirstOrDefault(c => c.Id == id);

            return serviceResponse;
        }
    }
}
