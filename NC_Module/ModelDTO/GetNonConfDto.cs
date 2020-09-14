using NC_Module.BLL;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NC_Module.ModelDTO
{
    public class GetNonConfDto
    {

        public string Code { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        //public List<CorrAction> CorrActions { get; set; }
    }
}
