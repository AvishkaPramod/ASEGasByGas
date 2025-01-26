using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.entities.Customer;
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
    public class CustomerManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<CustomerManager> _logger;

        /// <summary>
        /// Banks repository
        /// </summary>
        private readonly ICustomerRepositories _customerRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The Banks save mapper
        /// </summary>
        private readonly IMapper<CustomerRequestWrapper, CustomerSaveRequest> _customerSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public CustomerManager(ILogger <CustomerManager> logger,
            ICustomerRepositories customerRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<CustomerRequestWrapper, CustomerSaveRequest> CustomerSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _customerRepository = customerRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _customerSaveRequestMapper = CustomerSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add customer
        public async Task<ResponseBase> AddCustomerAsync(CustomerRequest request)
        {
            try
            {
                var CustomerSaveRequest = _customerSaveRequestMapper.Map(new CustomerRequestWrapper { Request = request });

                var userSaveResponse = await _customerRepository.SaveCustomerAsync(CustomerSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update Customer
        public async Task<ResponseBase> UpdateCustomerAsync(CustomerRequest request)
        {
            try
            {

                var CustomerUpdateRequest = _customerSaveRequestMapper.Map(new CustomerRequestWrapper { Request = request });

                var CustomerResponse = await _customerRepository.UpdateCustomerAsync(CustomerUpdateRequest);

                return _serviceResponseMapper.Map(CustomerResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllCustomerAsync()
        {
            try
            {
                var CustomerResponse = await _customerRepository.GetAllCutomerAsync();
                return _serviceResponseMapper.Map(CustomerResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewCustomerAsync(CustomerRequest request)
        {
            try
            {
                var CustomerDetail = await _customerRepository.GetCustomerDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(CustomerDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteCustomerAsync(CustomerRequest userequest)
        {
            try
            {
                var result = await _customerRepository.DeleteCustomerAsync(userequest.Attributes);
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
