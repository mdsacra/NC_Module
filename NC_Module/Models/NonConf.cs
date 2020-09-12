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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; }
        
        public int Version { get; internal set; }
        public int Status { get; internal set; }
        public string Description { get; internal set; }
        
        public List<CorrAction> CorrActions { get; internal set; }
    }
}
