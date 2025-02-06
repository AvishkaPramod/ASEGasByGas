using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Customer;
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
    public class GasStockManager: IGasStockManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<GasStockManager> _logger;

        /// <summary>
        /// Banks repository
        /// </summary>
        private readonly IGasStockRepositories _gasstockRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The Banks save mapper
        /// </summary>
        private readonly IMapper<GasStockRequestWrapper, GasStockSaveRequest> _gasstockSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public GasStockManager(ILogger<GasStockManager> logger,
            IGasStockRepositories gasstockRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<GasStockRequestWrapper, GasStockSaveRequest> gasstockSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _gasstockRepository = gasstockRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _gasstockSaveRequestMapper = gasstockSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add 
        public async Task<ResponseBase> AddGasStockAsync(GasStockRequest request)
        {
            try
            {
                var GasStockSaveRequest = _gasstockSaveRequestMapper.Map(new GasStockRequestWrapper { Request = request });

                var userSaveResponse = await _gasstockRepository.SaveGaasStockAsync(GasStockSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<ResponseBase> UpdateGasStockAsync(GasStockRequest request)
        {
            try
            {

                var GasStockUpdateRequest = _gasstockSaveRequestMapper.Map(new GasStockRequestWrapper { Request = request });

                var GasStockResponse = await _gasstockRepository.UpdateGasStockAsync(GasStockUpdateRequest);

                return _serviceResponseMapper.Map(GasStockResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllGasStockAsync()
        {
            try
            {
                var GasStockResponse = await _gasstockRepository.GetAllGasStockAsync();
                return _serviceResponseMapper.Map(GasStockResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewGasStockAsync(GasStockRequest request)
        {
            try
            {
                var GasStockDetail = await _gasstockRepository.GetGasStockDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(GasStockDetail);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteGasStockAsync(GasStockRequest userrequest)
        {
            try
            {
                var result = await _gasstockRepository.DeleteGasStockAsync(userrequest.Attributes);
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
