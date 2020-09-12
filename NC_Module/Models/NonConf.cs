using System;
using System.Collections.Generic;
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

        [Timestamp]
        public DateTime Date { get; set; }
        
        public int Version { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        
        [NotMapped]
        public List<CorrAction> Actions { get; set; }
    }
}
