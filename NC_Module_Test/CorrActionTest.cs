using Microsoft.Extensions.DependencyInjection;
using NC_Module.Data;
using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.CorrActionService;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NC_Module_Test
{
    public class CorrActionTest : IClassFixture<FixturesTestNonConf>
    {

        private ICorrActionService _corrActionService;
        private ServiceResponse<CorrActionDto> _serviceResponse;
        private DataContext _context;

        public CorrActionTest(FixturesTestNonConf fixture)
        {
            _corrActionService = fixture.ServiceProvider.GetRequiredService<ICorrActionService>();
            _context = fixture.ServiceProvider.GetRequiredService<DataContext>();

        }


        [Fact]
        public void Post_ShouldAddNewCorrAction()
        {
            _serviceResponse = _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything." });

            Assert.IsType<CorrActionDto>(_serviceResponse.Data);

        }

        [Fact]
        public void Get_ShouldReturnCorrectCorrActionById()
        {
            _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything1." });
            _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything2." });
            _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything3." });

            _serviceResponse = _corrActionService.GetCorrActionById(2);

            Assert.Equal("Do Anything2.", _serviceResponse.Data.Description);

        }

        [Fact]
        public void Get_ShouldReturnAllCorrActionsInList()
        {
            _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything1." });
            _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything2." });
            _corrActionService.AddCorrAction(new CorrActionDto() { Description = "Do Anything3." });

            var listCorrAction = _corrActionService.GetAllCorrActions().Data;

            Assert.Equal(3, listCorrAction.Count);

        }
    }
}
