﻿using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.NonConfService
{
    public interface INonConfBLL
    {

        NonConfDto CreateNonConf(int status, string description);
        
        
    }
}
