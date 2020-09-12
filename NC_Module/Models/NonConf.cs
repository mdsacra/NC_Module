using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Models
{
    public class NonConf
    {     
        public int Id {get; private set; }
        public DateTime Date { get; private set; }
        public int Version { get; private set; }
        public string Code { get; private set; }
        public int Status { get; private set; }
        public string Description { get; private set; }
        public List<Action> Actions { get; private set; }

        public NonConf(int version, int status, string description)
        {
            Id = 1;
            Date = new DateTime(2020,09,11);
            Version = version;
            Status = status;
            Description = description;
            Code = Date.Year.ToString() + ":0" + Id.ToString() + ":0" + version.ToString();

        }

        public override string ToString()
        {
            return "Code: " + this.Code;
        }



    }
}
