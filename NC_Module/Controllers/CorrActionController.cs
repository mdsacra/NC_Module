using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.CorrActionService;

namespace NC_Module.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CorrActionController : ControllerBase
    {
        private readonly ICorrActionService _corrActionService;

        public CorrActionController(ICorrActionService corrActionService)
        {
            _corrActionService = corrActionService;
        }

        [Route("All")]
        public IActionResult Get()
        {
            if (_corrActionService.GetAllCorrActions().Data.Count() == 0)
            {
                return NoContent();
            }
            
            return Ok(_corrActionService.GetAllCorrActions().Data);
        }


        [Route("{Id}")]
        public IActionResult GetById(int id)
        {
            ServiceResponse<CorrActionDto> serviceResponse = _corrActionService.GetCorrActionById(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse.Message);
            }
            return Ok(serviceResponse.Data);
        }

        [HttpPost]
        public IActionResult Post(CorrActionDto corrAction)
        {
            ServiceResponse<CorrActionDto> serviceResponse = _corrActionService.AddCorrAction(corrAction);

            if (serviceResponse.Data == null)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);

        }


    }
}
