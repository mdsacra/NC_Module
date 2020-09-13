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
        private readonly INonConfBLL _nonConfBLL;

        public NonConfService(INonConfBLL nonConfBLL)
        {
            _nonConfBLL = nonConfBLL;
        }
        public ServiceResponse<List<NonConfDto>> GetAllNonConf()
        {
            return new ServiceResponse<List<NonConfDto>>();
        }


        public ServiceResponse<NonConfDto> GetNonConfById(int id)
        {
            return new ServiceResponse<NonConfDto>();
        }

        public ServiceResponse<NonConfDto> AddNonConf(NonConfDto nonConfDto)
        {
            ServiceResponse<NonConfDto> serviceResponse = new ServiceResponse<NonConfDto>();

            serviceResponse.Data = _nonConfBLL.CreateNonConf(nonConfDto.Status, nonConfDto.Description);

            return serviceResponse;
        }
    }
}
