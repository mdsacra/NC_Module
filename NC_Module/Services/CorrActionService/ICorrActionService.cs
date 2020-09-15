using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.CorrActionService
{
    public interface ICorrActionService
    {
        ServiceResponse<CorrActionDto> AddCorrAction(CorrActionDto corrAction);

        ServiceResponse<CorrActionDto> GetCorrActionById(int id);

        ServiceResponse<List<CorrActionDto>> GetAllCorrActions();

    }
}
