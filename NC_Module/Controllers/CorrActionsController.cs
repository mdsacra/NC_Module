using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NC_Module.DAL;
using NC_Module.Models;

namespace NC_Module.Controllers
{
    [Route("v1/corractions")]
    [ApiController]
    public class CorrActionsController : ControllerBase
    {
        [HttpGet]
        public List<CorrAction> Get([FromServices] DataContext dataContext)
        {
            return dataContext.corrActions.ToList();

        }

        [HttpPost]
        public void Post(
            [FromServices] DataContext context,
            [FromBody] CorrAction corrAction)
        {
            context.corrActions.Add(corrAction);
            context.SaveChanges();
            
        }

        
    }
}
