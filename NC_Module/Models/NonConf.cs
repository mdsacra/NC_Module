using Microsoft.CodeAnalysis.Diagnostics;
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
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Code { get; set; }

        public int Status { get; set; } = 0;
        
        public string Description { get; set; }

        public int Version { get; set; } = 1;

        public List<NonConfCorrActions> NonConfCorrActions { get; set; }






    }
}
