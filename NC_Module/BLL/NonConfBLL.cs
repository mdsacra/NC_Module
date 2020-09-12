using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.BLL
{
    public class NonConfBLL
    {

        public int status { get; set; }
        public string description { get; set; }
        public List<CorrAction> corrActionsList { get; set; }

        public NonConf CreateNc(int status, string description, List<CorrAction> corrActions)
        {
            NonConf nonConf = new NonConf();
            nonConf.Version = 1;
            nonConf.Status = status;
            nonConf.Description = description;
            nonConf.CorrActions = corrActions;
            return nonConf;

        }

        public NonConfDto MakeNcDTO(NonConf nonConf)
        {
            NonConfDto nonConfDto = new NonConfDto();

            nonConfDto.Code = ReturnCodeNc(nonConf);
            nonConfDto.Description = nonConf.Description;
            nonConfDto.Status = nonConf.Status;
            nonConfDto.CorrActions = nonConf.CorrActions;

            return nonConfDto;
        }

        private string ReturnCodeNc(NonConf nonConf)
        {
            return nonConf.Date.Year.ToString()
                + ":0" + nonConf.Id.ToString()
                + ":0" + nonConf.Version.ToString();
        }


    }
}
