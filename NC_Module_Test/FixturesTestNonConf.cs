using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NC_Module;
using NC_Module.Data;
using NC_Module.Services.CorrActionService;
using NC_Module.Services.NonConfCorrActionsService;
using NC_Module.Services.NonConfService;
using System;
using System.Collections.Generic;
using System.Text;

namespace NC_Module_Test
{
    public class FixturesTestNonConf
    {
        
        public ServiceProvider ServiceProvider { get; private set; }
        
        public FixturesTestNonConf()
        {
            var serviceCollection = new ServiceCollection();




            serviceCollection.AddDbContext<DataContext>(c => c.UseInMemoryDatabase("testes"));
            serviceCollection.AddTransient<INonConfService, NonConfService>();
            serviceCollection.AddTransient<INonConfCorrActionsService, NonConfCorrActionsService>();
            serviceCollection.AddTransient<ICorrActionService, CorrActionService>();
            
            serviceCollection.AddAutoMapper(typeof(Startup));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        
    }
}
