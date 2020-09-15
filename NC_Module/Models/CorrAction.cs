using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Models
{
    public class CorrAction
    {

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }

        public List<NonConfCorrActions> NonConfCorrActions { get; set; }
        
       
        



    }
}
