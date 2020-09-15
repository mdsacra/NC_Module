using Microsoft.AspNetCore.Mvc;
using NC_Module.ModelDTO.NonConfCorrActionsDto;
using NC_Module.Services.NonConfCorrActionsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class NonConfCorrActionsController : ControllerBase
    {
        private readonly INonConfCorrActionsService _nonConfCorrActionsService;

        public NonConfCorrActionsController(INonConfCorrActionsService nonConfCorrActionsService)
        {
            _nonConfCorrActionsService = nonConfCorrActionsService;
        }

        public IActionResult AddNonConfCorrAction(NonConfCorrActionDto newNonConfCorrAction)
        {
            return Ok(_nonConfCorrActionsService.AddNonConfCorrActions(newNonConfCorrAction));
        }

    }
}
