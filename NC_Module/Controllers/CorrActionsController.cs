using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NC_Module.Models;

namespace NC_Module.Controllers
{
    [Route("v1/corractions")]
    [ApiController]
    public class CorrActionsController : ControllerBase
    {
        [HttpGet]
        public List<CorrAction> Get()
        {
            return new List<CorrAction>();

        }

       /* [HttpPost]
        public void Post(CorrAction corrAction)
        {
            

        }
*/
        
    }
}
