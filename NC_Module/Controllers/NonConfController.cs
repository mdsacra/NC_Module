using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NC_Module.DAL;
using NC_Module.Models;

namespace NC_Module.Controllers
{
    [Route("v1/nonconf")]
    [ApiController]
    public class NonConfController : ControllerBase
    {
        [HttpGet]
        public List<NonConf> Get([FromServices] DataContext context)
        {
            return context.nonConfs.ToList();
        }

        [HttpPost]
        public void Post(
            [FromServices] DataContext context,
            [FromBody] NonConf nonConf)
        {
            context.nonConfs.Add(nonConf);
            context.SaveChanges();

        }
    }
}
