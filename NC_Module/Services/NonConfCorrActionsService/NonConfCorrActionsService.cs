using AutoMapper;
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

        public NonConfCorrActionsService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ServiceResponse<GetNonConfDto> AddNonConfCorrActions(NonConfCorrActionsDto nonConfCorrActions)
        {
            ServiceResponse<GetNonConfDto> serviceResponse = new ServiceResponse<GetNonConfDto>();
            
            NonConf nonConf = _context.nonConfs.FirstOrDefault(n => n.Id == nonConfCorrActions.NonconfId);

            CorrAction corrAction = _context.corrActions.FirstOrDefault(c => c.Id == nonConfCorrActions.CorractionId);

            if (nonConf == null || corrAction == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "NC ou CorrAction não existe.";
                return serviceResponse;
            }

            if (nonConf.Status != 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Esta NC já está encerrada e não pode ser alterada.";
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
    }
}
