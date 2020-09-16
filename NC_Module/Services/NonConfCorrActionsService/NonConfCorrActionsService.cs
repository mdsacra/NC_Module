using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NC_Module.Data;
using NC_Module.ModelDTO;
using NC_Module.ModelDTO.NonConfCorrActionsDto;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.Services.NonConfCorrActionsService
{
    public class NonConfCorrActionsService : INonConfCorrActionsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        ServiceResponse<GetNonConfDto> serviceResponse = new ServiceResponse<GetNonConfDto>();

        public NonConfCorrActionsService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceResponse<GetNonConfDto> AddNonConfCorrActions(NonConfCorrActionsDto nonConfCorrActions)
        {
            
            NonConf nonConf = _context.nonConfs.Find(nonConfCorrActions.NonconfId);
            CorrAction corrAction = _context.corrActions.Find(nonConfCorrActions.CorractionId);

            if (NonConfCorrActionsValidator(nonConf, corrAction) == false)
            {
                return serviceResponse;
            }

            try
            {
                NonConfCorrActions newNonConfCorrActions = new NonConfCorrActions
                {
                    NonConf = nonConf,
                    CorrAction = corrAction
                };

                _context.nonConfCorrActions.Add(newNonConfCorrActions);
                _context.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetNonConfDto>(nonConf);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Não foi possível processar a requisição. Exception: " + ex.Message;
            }

            return serviceResponse;
        
        }



        private bool NonConfCorrActionsValidator(NonConf nonConf, CorrAction corrAction)
        {
            if (nonConf == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "A NC não existe.";
                return false;
            }
            else if (corrAction == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "A Ação não existe.";
                return false;
            }
            else if (nonConf.Status != 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Esta NC está encerrada e não pode ser alterada.";
                return false;
            }

            return true;


        }
    }
}
