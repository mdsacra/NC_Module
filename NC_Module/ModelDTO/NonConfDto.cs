using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.ModelDTO
{
    public class NonConfDto
    {
        public string Code { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public List<CorrAction> Actions { get; set; }
    }
}
