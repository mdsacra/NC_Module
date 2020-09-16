using Microsoft.Extensions.DependencyInjection;
using NC_Module.Data;
using NC_Module.ModelDTO;
using NC_Module.ModelDTO.NonConfCorrActionsDto;
using NC_Module.Models;
using NC_Module.Services.CorrActionService;
using NC_Module.Services.NonConfCorrActionsService;
using NC_Module.Services.NonConfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NC_Module_Test
{
    public class NonConfCorrActionsTest : IClassFixture<FixturesTestNonConf>
    {

        private INonConfCorrActionsService _nonConfCorrActionsService;
        private INonConfService _nonConfService;
        private ICorrActionService _corrActionService;
        private ServiceResponse<GetNonConfDto> _serviceResponse;
        private DataContext _context;

        public NonConfCorrActionsTest(FixturesTestNonConf fixture)
        {
            _nonConfCorrActionsService = fixture.ServiceProvider.GetRequiredService<INonConfCorrActionsService>();
            _nonConfService = fixture.ServiceProvider.GetRequiredService<INonConfService>();
            _corrActionService = fixture.ServiceProvider.GetRequiredService<ICorrActionService>();
            _context = fixture.ServiceProvider.GetRequiredService<DataContext>();
        }

        [Fact]
        public void Post_ShouldInsertANewCorrActionInANonConf()
        {
            CorrActionDto corrAction = new CorrActionDto() { Id = 1, Description = "Do Anything." };

            _nonConfService.AddNonConf(new NonConf() { Id = 1 });
            _corrActionService.AddCorrAction(corrAction);

            NonConfCorrActionsDto nonConfCorrActions = new NonConfCorrActionsDto() { NonconfId = 1, CorractionId = 1 };
            
            _nonConfCorrActionsService.AddNonConfCorrActions(nonConfCorrActions);

            List<CorrActionDto> corrActionsInNonConf = _nonConfService.GetNonConfById(1).Data.CorrActions;

            Assert.Equal(corrAction.Id, corrActionsInNonConf[0].Id);
        }

        [Fact]
        public void Post_ShouldNotAllowInsertCorrActionsInClosedNonConf()
        {
            _nonConfService.AddNonConf(new NonConf() { Id = 1, Status = 1 });
            _corrActionService.AddCorrAction(new CorrActionDto() { Id = 1, Description = "Do Anything." });

            NonConfCorrActionsDto nonConfCorrActions = new NonConfCorrActionsDto() { NonconfId = 2, CorractionId = 1 };

            _serviceResponse = _nonConfCorrActionsService.AddNonConfCorrActions(nonConfCorrActions);

            Assert.False(_serviceResponse.Success);
        }

        [Fact]
        public void Get_ShouldReturnFalseIfIdNotExist()
        {
            _nonConfService.AddNonConf(new NonConf() { Id = 1 });
            _corrActionService.AddCorrAction(new CorrActionDto() { Id = 1, Description = "Do Anything." });

            NonConfCorrActionsDto nonConfCorrActions = new NonConfCorrActionsDto() { NonconfId = 2, CorractionId = 1 };

            _serviceResponse = _nonConfCorrActionsService.AddNonConfCorrActions(nonConfCorrActions);

            Assert.False(_serviceResponse.Success);
        }

        
    }
}
