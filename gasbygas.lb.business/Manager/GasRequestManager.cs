using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Manager
{
    public class GasRequestManager: IGasRequestManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<GasRequestManager> _logger;

        /// <summary>
        /// Banks repository
        /// </summary>
        private readonly IGasRequestRepositories _gasRequestRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The Banks save mapper
        /// </summary>
        private readonly IMapper<GasRequestRequestWrapper, GasRequestSaveRequest> _gasRequestSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public GasRequestManager(ILogger<GasRequestManager> logger,
            IGasRequestRepositories gasRequestRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<GasRequestRequestWrapper, GasRequestSaveRequest> gasRequestSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _gasRequestRepository = gasRequestRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _gasRequestSaveRequestMapper = gasRequestSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add 
        public async Task<ResponseBase> AddGasRequestAsync(GasRequestRequest request)
        {
            try
            {
                var GasRequestSaveRequest = _gasRequestSaveRequestMapper.Map(new GasRequestRequestWrapper { Request = request });

                var userSaveResponse = await _gasRequestRepository.SaveGasRequestAsync(GasRequestSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<ResponseBase> UpdateGasRequestAsync(GasRequestRequest request)
        {
            try
            {

                var GasRequestUpdateRequest = _gasRequestSaveRequestMapper.Map(new GasRequestRequestWrapper { Request = request });

                var GasRequestResponse = await _gasRequestRepository.UpdateGasRequestAsync(GasRequestUpdateRequest);

                return _serviceResponseMapper.Map(GasRequestResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllGasRequestAsync()
        {
            try
            {
                var GasRequestResponse = await _gasRequestRepository.GetAllGasRequestAsync();
                return _serviceResponseMapper.Map(GasRequestResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewGasRequestAsync(GasRequestRequest request)
        {
            try
            {
                var GasRequestDetail = await _gasRequestRepository.GetGasRequestDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(GasRequestDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteGasRequestAsync(GasRequestRequest userrequest)
        {
            try
            {
                var result = await _gasRequestRepository.DeleteGasRequestAsync(userrequest.Attributes);
                return _serviceResponseMapper.Map(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
