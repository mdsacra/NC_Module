using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NC_Module.BLL;
using NC_Module.DAL;
using NC_Module.ModelDTO;
using NC_Module.Models;

namespace NC_Module.Controllers
{
    [Route("v1/nonconf")]
    [ApiController]
    public class NonConfController : ControllerBase
    {
        [HttpGet]
        [Route("{Id}")]
        public NonConfDto Get([FromServices] DataContext context, int Id)
        {

            NonConf nonConf = context.nonConfs.Find(Id);
            NonConfBLL nonConfBLL = new NonConfBLL();
            return nonConfBLL.MakeNcDTO(nonConf);

            
        }

        [HttpPost]
        public void Post(
            [FromServices] DataContext context,
            [FromBody] NonConfDto nonConfDto)
        {
       
            NonConfBLL nonConfBLL = new NonConfBLL();

            NonConf nonConf = nonConfBLL.CreateNc(nonConfDto.Status, nonConfDto.Description, nonConfDto.CorrActions);

            context.nonConfs.Add(nonConf);
            context.SaveChanges();

        }
    }
}
