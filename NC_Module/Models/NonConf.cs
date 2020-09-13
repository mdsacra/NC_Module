using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Models
{
    public class NonConf
    {     


        [Key]
        public int NonConfId { get; set; }
        public DateTime Date { get; internal set; } = DateTime.Now;
        public int Version { get; internal set; } = 1;
        public int Status { get; internal set; }
        public string Description { get; internal set; }

        public List<NonConfCorrActions> nonConfCorrActions { get; set; }

    }
}
