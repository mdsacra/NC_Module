using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
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
        private DbContext _context;

        
        
        public NonConfTest(FixturesTestNonConf fixture)
        {
            _nonConfService = fixture.ServiceProvider.GetRequiredService<INonConfService>();

            
            
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
        public void Get_ShouldReturnCorrectNonConfById()
        {
            _serviceResponse = _nonConfService.AddNonConf(new NonConf());
            
            int id = _serviceResponse.Data.Id;

            Assert.Equal(4, _nonConfService.GetNonConfById(id).Data.Id);
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
            
            var listNonConf = _nonConfService.GetAllNonConf();

            Assert.Equal(6, listNonConf.Data.Count);
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

            UpdateNonConfDto upNc = new UpdateNonConfDto() { Id = 8, Status = 0 };

            _serviceResponse = _nonConfService.EvaluateNonConf(upNc);

            Assert.False(_serviceResponse.Success);
        }

        [Fact]
        public void Put_ShouldCreateNewVersionNc()
        {
            _nonConfService.AddNonConf(new NonConf());
            
            UpdateNonConfDto upNc = new UpdateNonConfDto() { Id = 9, Status = 2 };

            _serviceResponse = _nonConfService.EvaluateNonConf(upNc);

            Assert.Equal("2020:010:02", _serviceResponse.Data.Code);
        }

        [Fact]
        public void Put_ShouldCloseCurrentNc()
        {
            _nonConfService.AddNonConf(new NonConf());
            UpdateNonConfDto upNc = new UpdateNonConfDto() { Id = 10, Status = 1 };

            _serviceResponse = _nonConfService.EvaluateNonConf(upNc);

            Assert.Contains("encerrada", _serviceResponse.Message);

        }

        internal void DeleteDb() => _context.Database.EnsureDeleted();
        
    }
}
