using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.ModelDTO
{
    public class NonConfDto
    {
        public string Code { get; internal set; }
        public int Status { get; internal set; }
        public string Description { get; internal set; }
        public List<CorrAction> CorrActions { get; internal set; }
    }
}
