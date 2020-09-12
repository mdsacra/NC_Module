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
        public int Id { get; private set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public List<NonConf> NonConfs { get; set; }

       

    }
}
