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
                + ":0" + nonConf.NonConfId.ToString()
                + ":0" + nonConf.Version.ToString();
            
        }

        public NonConf EvaluateNc(NonConf nonConf)
        {
            if (nonConf.Status == 2)
            {
                return EvaluateNonEffectiveNc(nonConf);
            } else
            {
                nonConf.Status = 1;
                return nonConf;
            }
            
                
        }

        private NonConf EvaluateNonEffectiveNc(NonConf nonConf)
        {
            NonConf newNonConf = new NonConf();
            
            newNonConf.Description = nonConf.Description;
            newNonConf.Version = nonConf.Version + 1;
            NcCodeGenerator(newNonConf);

            nonConf.Status = 2;

            return newNonConf;
            
        }


    }
}
