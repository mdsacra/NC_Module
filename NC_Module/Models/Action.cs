using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Models
{
    public class Action
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public List<NonConf> NonConfs { get; private set; }

       

    }
}
