using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.NonConfService;

namespace NC_Module.Controllers
{
    [Route("v1/nonconf")]
    [ApiController]
    public class NonConfController : ControllerBase
    {
        
        private readonly INonConfService _nonConfService;

        public NonConfController(INonConfService nonConfService)
        {
            _nonConfService = nonConfService;
        }

        [Route("all")]
        public IActionResult Get()
        {
            return Ok(_nonConfService.GetAllNonConf()); 
        }

        [Route("{Id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_nonConfService.GetNonConfById(id));
        }

        [HttpPost]
        public IActionResult Post(NonConf nonConf)
        {
            return Ok(_nonConfService.AddNonConf(nonConf));
        }

        [HttpPut]
        public IActionResult Put(UpdateNonConfDto updateNonConfDto)
        {
            return Ok(_nonConfService.EvaluateNonConf(updateNonConfDto));

        }

    }
}
