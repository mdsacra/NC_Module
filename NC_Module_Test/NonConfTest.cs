using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using NC_Module.Data;
using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.NonConfService;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NC_Module_Test
{
    public class NonConfTest : IClassFixture<FixturesTestNonConf>
    {
        
        private INonConfService _nonConfService;
        private ServiceResponse<GetNonConfDto> _serviceResponse;
        private DataContext _context;
        
        public NonConfTest(FixturesTestNonConf fixture)
        {
            _nonConfService = fixture.ServiceProvider.GetRequiredService<INonConfService>();
            _context = fixture.ServiceProvider.GetRequiredService<DataContext>();

        }


        [Fact]
        public void Post_ShouldAddNewNonConf()
        {
            _serviceResponse = _nonConfService.AddNonConf(new NonConf());
            
            Assert.IsType<GetNonConfDto>(_serviceResponse.Data);
            
        }

        [Fact]
        public void Post_ShouldReturnCorrectCode()
        {
            _serviceResponse = _nonConfService.AddNonConf(new NonConf());
            
            Assert.Equal("2020:01:01", _serviceResponse.Data.Code);
        }

        [Fact]
        public void Post_ShouldSaveInitialStatus()
        {
            _serviceResponse = _nonConfService.AddNonConf(new NonConf());

            Assert.Equal(0, _serviceResponse.Data.Status);
        }

        [Fact]
        public void Post_ShouldReturnErrorIfStatusGreaterThen2()
        {
            _serviceResponse = _nonConfService.AddNonConf(new NonConf()
            {
                Status = 3
            });

            Assert.False(_serviceResponse.Success);
        }


        [Fact]
        public void Get_ShouldReturnCorrectNonConfById()
        {
            _serviceResponse = _nonConfService.AddNonConf(new NonConf());
            
            int id = _nonConfService.GetNonConfById(1).Data.Id;

            Assert.Equal(1, id);
        }

        [Fact]
        public void Get_ShouldThrowFalseSuccessIfIdIsNotValid()
        {

            _nonConfService.AddNonConf(new NonConf());

            _serviceResponse = _nonConfService.GetNonConfById(6);

            Assert.False(_serviceResponse.Success);
        }

        [Fact]
        public void Get_ShouldReturnAllNonConfsInList()
        {
            _nonConfService.AddNonConf(new NonConf());
            _nonConfService.AddNonConf(new NonConf());
            _nonConfService.AddNonConf(new NonConf());

            var listNonConf = _nonConfService.GetAllNonConf().Data;

            
            Assert.Equal(3, listNonConf.Count);
        }

        [Fact]
        public void Put_ShouldReturnSuccessFalseIfIdIsNotValid()
        {
            UpdateNonConfDto upNc = new UpdateNonConfDto();
            
            _serviceResponse = _nonConfService.EvaluateNonConf(upNc);

            Assert.False(_serviceResponse.Success);

        }

        [Fact]
        public void Put_ShouldNotAllowChangeClosedNc()
        {
            _nonConfService.AddNonConf(new NonConf(){ Status = 1 });

            UpdateNonConfDto upNc = new UpdateNonConfDto() { Id = 1, Status = 0 };

            _serviceResponse = _nonConfService.EvaluateNonConf(upNc);

            Assert.False(_serviceResponse.Success);
        }

        [Fact]
        public void Put_ShouldCreateNewVersionNc()
        {
            _nonConfService.AddNonConf(new NonConf());
            
            UpdateNonConfDto upNc = new UpdateNonConfDto() { Id = 1, Status = 2 };

            _nonConfService.EvaluateNonConf(upNc);
            GetNonConfDto nonConfDto = _nonConfService.GetNonConfById(2).Data;

            Assert.Equal("2020:02:02", nonConfDto.Code);
        }

        [Fact]
        public void Put_ShouldCloseCurrentNc()
        {
            _nonConfService.AddNonConf(new NonConf());
            UpdateNonConfDto upNc = new UpdateNonConfDto() { Id = 1, Status = 1 };

            _serviceResponse = _nonConfService.EvaluateNonConf(upNc);

            Assert.Contains("encerrada", _serviceResponse.Message);

        }

        
    }
}
