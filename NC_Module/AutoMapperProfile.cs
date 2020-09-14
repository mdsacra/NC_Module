using AutoMapper;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NonConf, GetNonConfDto>();
            CreateMap<UpdateNonConfDto, NonConf>();

        }
    }
}
