using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.OutletStock;
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
    public class OutletStockManager: IOutletStockManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<OutletStockManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly IOutletStockRepositories _outletStockRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<OutletStockRequestWrapper, OutletStockSaveRequest> _outletStockSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public OutletStockManager(ILogger<OutletStockManager> logger,
            IOutletStockRepositories outletStockRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<OutletStockRequestWrapper, OutletStockSaveRequest> outletStockSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _outletStockRepository = outletStockRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _outletStockSaveRequestMapper = outletStockSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddOutletStockAsync(OutletStockRequest request)
        {
            try
            {
                var OutletStockSaveRequest = _outletStockSaveRequestMapper.Map(new OutletStockRequestWrapper { Request = request });

                var userSaveResponse = await _outletStockRepository.SaveOutletStockAsync(OutletStockSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdateOutletStockAsync(OutletStockRequest request)
        {
            try
            {

                var OutletStockUpdateRequest = _outletStockSaveRequestMapper.Map(new OutletStockRequestWrapper { Request = request });

                var OutletStockResponse = await _outletStockRepository.UpdateOutletStockAsync(OutletStockUpdateRequest);

                return _serviceResponseMapper.Map(OutletStockResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllOutletStockAsync()
        {
            try
            {
                var OutletStockResponse = await _outletStockRepository.GetAllOutletStockAsync();
                return _serviceResponseMapper.Map(OutletStockResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewOutletStockAsync(OutletStockRequest request)
        {
            try
            {
                var OutletStockDetail = await _outletStockRepository.GetOutletStockDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(OutletStockDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteOutletStockAsync(OutletStockRequest userequest)
        {
            try
            {
                var result = await _outletStockRepository.DeleteOutletStockAsync(userequest.Attributes);
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

