using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Payment;
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
    public class PaymentManager: IPaymentManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<PaymentManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly IPaymentRepositories _paymentRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<PaymentRequestWrapper, PaymentSaveRequest> _paymentSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public PaymentManager(ILogger<PaymentManager> logger,
            IPaymentRepositories paymentRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<PaymentRequestWrapper, PaymentSaveRequest> paymentSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _paymentRepository = paymentRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _paymentSaveRequestMapper = paymentSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddPaymentAsync(PaymentRequest request)
        {
            try
            {
                var PaymentSaveRequest = _paymentSaveRequestMapper.Map(new PaymentRequestWrapper { Request = request });

                var userSaveResponse = await _paymentRepository.SavePaymentAsync(PaymentSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdatePaymentAsync(PaymentRequest request)
        {
            try
            {

                var PaymentUpdateRequest = _paymentSaveRequestMapper.Map(new PaymentRequestWrapper { Request = request });

                var PaymentResponse = await _paymentRepository.UpdatePaymentAsync(PaymentUpdateRequest);

                return _serviceResponseMapper.Map(PaymentResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllPaymentAsync()
        {
            try
            {
                var PaymentResponse = await _paymentRepository.GetAllPaymentAsync();
                return _serviceResponseMapper.Map(PaymentResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewPaymentAsync(PaymentRequest request)
        {
            try
            {
                var PaymentDetail = await _paymentRepository.GetPaymentDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(PaymentDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeletePaymentAsync(PaymentRequest userequest)
        {
            try
            {
                var result = await _paymentRepository.DeletePaymentAsync(userequest.Attributes);
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
