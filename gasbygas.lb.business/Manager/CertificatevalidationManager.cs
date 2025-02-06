using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Cetificatevalidaton;
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
    public class CertificatevalidationManager: ICertificatevalidationManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<CertificatevalidationManager> _logger;

        /// <summary>
        /// Certificatevalidatoin repository
        /// </summary>
        private readonly ICertificatevalidationRepositories _certificatevalidationRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The Certificatevalidatoin save mapper
        /// </summary>
        private readonly IMapper<CertificatevalidationRequestWrapper, CertificatevalidationSaveRequest> _certificatevalidationSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public CertificatevalidationManager(ILogger<CertificatevalidationManager> logger,
            ICertificatevalidationRepositories certificatevalidationRepository,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<CertificatevalidationRequestWrapper, CertificatevalidationSaveRequest> certificatevalidationSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _certificatevalidationRepository = certificatevalidationRepository;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _certificatevalidationSaveRequestMapper = certificatevalidationSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;

        }

        //Add 
        public async Task<ResponseBase> AddCertificatevalidationAsync(CertificatevalidationRequest request)
        {
            try
            {
                var CertificateValidationSaveRequest = _certificatevalidationSaveRequestMapper.Map(new CertificatevalidationRequestWrapper { Request = request });

                var userSaveResponse = await _certificatevalidationRepository.SaveCertificatevalidationAsync(CertificateValidationSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<ResponseBase> UpdateCertificatevalidationAsync(CertificatevalidationRequest request)
        {
            try
            {

                var CertificateValidationUpdateRequest = _certificatevalidationSaveRequestMapper.Map(new CertificatevalidationRequestWrapper { Request = request });

                var CertificateValidationUpdateResponse = await _certificatevalidationRepository.UpdateCertificatevalidationAsync(CertificateValidationUpdateRequest);

                return _serviceResponseMapper.Map(CertificateValidationUpdateResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllCertificatevalidationAsync()
        {
            try
            {
                var CertificateValidationResponse = await _certificatevalidationRepository.GetAllCertificatevalidationAsync();
                return _serviceResponseMapper.Map(CertificateValidationResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewCertificatevalidationAsync(CertificatevalidationRequest request)
        {
            try
            {
                var CertificateValidationDetail = await _certificatevalidationRepository.GetCertificatevalidationDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(CertificateValidationDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteCertificatevalidationAsync(CertificatevalidationRequest userrequest)
        {
            try
            {
                var result = await _certificatevalidationRepository.DeleteCertificatevalidationAsync(userrequest.Attributes);
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
