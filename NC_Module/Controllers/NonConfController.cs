using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NC_Module.BLL;
using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.NonConfService;

namespace NC_Module.Controllers
{
    [Route("v1/nonconf")]
    [ApiController]
    public class NonConfController : ControllerBase
    {
        
        private readonly INonConfBLL _nonConfBLL;

        public NonConfController(INonConfService nonConfService)
        {
            _nonConfBLL = nonConfService;
        }

        [Route("all")]
        public IActionResult Get()
        {
            return Ok(_nonConfBLL.GetAllNonConf()); 
        }

        [Route("{Id}")]
        public IActionResult GetSingle(int id)
        {
            return NotFound(id);
        }

        [HttpPost]
        public IActionResult Post(NonConfDto nonConfDto)
        {
            return Ok(_nonConfBLL.CreateNonConf(nonConfDto.Status, nonConfDto.Description));
        }

    }
}
