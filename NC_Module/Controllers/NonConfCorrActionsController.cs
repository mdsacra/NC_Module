﻿using Microsoft.AspNetCore.Mvc;
using NC_Module.ModelDTO;
using NC_Module.ModelDTO.NonConfCorrActionsDto;
using NC_Module.Models;
using NC_Module.Services.NonConfCorrActionsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NonConfCorrActionsController : ControllerBase
    {
        private readonly INonConfCorrActionsService _nonConfCorrActionsService;

        public NonConfCorrActionsController(INonConfCorrActionsService nonConfCorrActionsService)
        {
            _nonConfCorrActionsService = nonConfCorrActionsService;
        }
        
        [HttpPost]
        public IActionResult AddNonConfCorrAction(NonConfCorrActionsDto newNonConfCorrAction)
        {
            ServiceResponse<GetNonConfDto> serviceResponse = _nonConfCorrActionsService.AddNonConfCorrActions(newNonConfCorrAction);
            
            if (serviceResponse.Success == false)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);
        }

    }
}
