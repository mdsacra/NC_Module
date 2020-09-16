using NC_Module.ModelDTO;
using NC_Module.ModelDTO.NonConfCorrActionsDto;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.NonConfCorrActionsService
{
    public interface INonConfCorrActionsService
    {
        ServiceResponse<GetNonConfDto> AddNonConfCorrActions(NonConfCorrActionsDto nonConfCorrActions);
    }
}
