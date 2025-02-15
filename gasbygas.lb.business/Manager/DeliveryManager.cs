using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Outlet;
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
    public class DeliveryManager: IDeliveryManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<DeliveryManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly IDeliveryRepositories _deliveryRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<DeliveryRequestWrapper, DeliverySaveRequest> _deliverySaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public DeliveryManager(ILogger<DeliveryManager> logger,
            IDeliveryRepositories deliveryRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<DeliveryRequestWrapper, DeliverySaveRequest> deliverySaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _deliveryRepository = deliveryRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _deliverySaveRequestMapper = deliverySaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddDeliveryAsync(DeliveryRequest request)
        {
            try
            {
                var DeliverySaveRequest = _deliverySaveRequestMapper.Map(new DeliveryRequestWrapper { Request = request });

                var userSaveResponse = await _deliveryRepository.SaveDeliveryAsync(DeliverySaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdateDeliveryAsync(DeliveryRequest request)
        {
            try
            {

                var DeliveryUpdateRequest = _deliverySaveRequestMapper.Map(new DeliveryRequestWrapper { Request = request });

                var DeliveryResponse = await _deliveryRepository.UpdateDeliveryAsync(DeliveryUpdateRequest);

                return _serviceResponseMapper.Map(DeliveryResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllDeliveryAsync()
        {
            try
            {
                var DeliveryResponse = await _deliveryRepository.GetAllDeliveryAsync();
                return _serviceResponseMapper.Map(DeliveryResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewDeliveryAsync(DeliveryRequest request)
        {
            try
            {
                var DeliveryDetail = await _deliveryRepository.GetDeliveryDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(DeliveryDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteDeliveryAsync(DeliveryRequest userequest)
        {
            try
            {
                var result = await _deliveryRepository.DeleteDeliveryAsync(userequest.Attributes);
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
