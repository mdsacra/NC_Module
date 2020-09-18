using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using NC_Module.ModelDTO;
using NC_Module.ModelDTO.NonConfCorrActionsDto;
using NC_Module.Models;
using NC_Module.Services.CorrActionService;
using NC_Module.Services.NonConfCorrActionsService;
using NC_Module.Services.NonConfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Data
{
    public class DbInitializer
    {

        public static void Initialize(DataContext context, IMapper mapper)
        {

            NonConfService nonConfService = new NonConfService(context, mapper);
            CorrActionService corrActionService = new CorrActionService(context, mapper);
            NonConfCorrActionsService nonConfCorrActionsService = new NonConfCorrActionsService(context, mapper);

            context.Database.EnsureCreated();

            if (context.nonConfs.Any())
            {
                return;
            }

            //Insere as NonConfs
            var newNonConfs = new NonConf[]
            {
                new NonConf(),
                new NonConf {Status = 1},
                new NonConf()
            };

            foreach(NonConf n in newNonConfs)
            {
                nonConfService.AddNonConf(n);
                
            }

            //Insere as CorrActions
            var newCorrActions = new CorrActionDto[]
            {
                new CorrActionDto {Description = "Do Anything 01."},
                new CorrActionDto {Description = "Do Anything 02."}
            };

            foreach(CorrActionDto c in newCorrActions)
            {
                corrActionService.AddCorrAction(c);
            }


            //Relaciona uma CorrAction com uma NonConf
            nonConfCorrActionsService.AddNonConfCorrActions(new NonConfCorrActionsDto()
            {
                NonconfId = 1,
                CorractionId = 1
            });

            
        }
    }
}
