using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.NonConfService
{
    public interface INonConfService
    {
        ServiceResponse<List<GetNonConfDto>> GetAllNonConf();

        ServiceResponse<GetNonConfDto> GetNonConfById(int id);

        ServiceResponse<GetNonConfDto> AddNonConf(NonConf nonConf);

        ServiceResponse<GetNonConfDto> EvaluateNonConf(UpdateNonConfDto updateNonConfDto);

        
    }
}
