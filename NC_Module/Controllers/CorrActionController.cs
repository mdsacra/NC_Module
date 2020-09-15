using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
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

        
        public IActionResult Get()
        {
            return Ok(_corrActionService.GetAllCorrActions());
        }


        [Route("{Id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_corrActionService.GetCorrActionById(id));
        }

        [HttpPost]
        public IActionResult Post(CorrAction corrAction)
        {
            return Ok(_corrActionService.AddCorrAction(corrAction));

        }


    }
}
