using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.CorrActionService
{
    public interface ICorrActionService
    {
        ServiceResponse<CorrAction> AddCorrAction(CorrAction corrAction);

        ServiceResponse<CorrAction> GetCorrActionById(int id);

        ServiceResponse<List<CorrAction>> GetAllCorrActions();

    }
}
