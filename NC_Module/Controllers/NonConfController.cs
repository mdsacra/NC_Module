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
    [Route("[controller]")]
    [ApiController]
    public class NonConfController : ControllerBase
    {
        
        private readonly INonConfService _nonConfService;

        public NonConfController(INonConfService nonConfService)
        {
            _nonConfService = nonConfService;
        }


        [Route("{Id}")]
        public IActionResult GetById(int id)
        {
            ServiceResponse<GetNonConfDto> serviceResponse = _nonConfService.GetNonConfById(id);
            if (serviceResponse.Data == null)
            {
                
                return NotFound(serviceResponse.Message);

            }

            return Ok(serviceResponse.Data);
        }


        [Route("All")]
        public IActionResult Get()
        {
            if (_nonConfService.GetAllNonConf().Data.Count() == 0)
            {
                return NoContent();
            }
            return Ok(_nonConfService.GetAllNonConf().Data);
        }

        

        [HttpPost]
        public IActionResult Post(NonConf nonConf)
        {
            ServiceResponse<GetNonConfDto> serviceResponse = _nonConfService.AddNonConf(nonConf);

            if (serviceResponse.Data == null)
            {
                return BadRequest(serviceResponse.Message);
            }
            return Ok(serviceResponse);
        }

        [HttpPut]
        public IActionResult Put(UpdateNonConfDto updateNonConfDto)
        {
            ServiceResponse<GetNonConfDto> serviceResponse = _nonConfService.EvaluateNonConf(updateNonConfDto);

            if (serviceResponse.Data == null)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);
        }

    }
}
