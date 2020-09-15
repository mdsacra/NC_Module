using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Models
{
    public class NonConfCorrActions
    {
        public int NonconfId { get; set; }
        public NonConf NonConf { get; set; }
        public int CorractionId { get; set; }
        public CorrAction CorrAction { get; set; }
    }
}
