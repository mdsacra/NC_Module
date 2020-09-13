using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.NonConfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.BLL
{
    public class NonConfBLL
    {

        public NonConfDto CreateNonConf(int status, string description)
        {
            return MakeNcDto(new NonConf { Status = status, Description = description });
        }
                
        private NonConfDto MakeNcDto(NonConf nonConf)
        {
            NonConfDto nonConfDto = new NonConfDto();
            nonConfDto.Code = ReturnCodeNc(nonConf);
            nonConfDto.Description = nonConf.Description;
            nonConfDto.Status = nonConf.Status;

            return nonConfDto;
        }

        private string ReturnCodeNc(NonConf nonConf)
        {
            return nonConf.Date.Year.ToString()
                + ":0" + nonConf.NonConfId.ToString()
                + ":0" + nonConf.Version.ToString();
        }
    }
}
