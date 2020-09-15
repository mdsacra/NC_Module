using Microsoft.CodeAnalysis.CSharp.Syntax;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.BLL.NonConfBLL
{
    public class NonConfBLL
    {

        public void NcCodeGenerator(NonConf nonConf)
        {
            
            nonConf.Code = nonConf.Date.Year.ToString()
                + ":0" + nonConf.Id.ToString()
                + ":0" + nonConf.Version.ToString();
            
        }

    }
}
