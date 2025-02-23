using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Token;
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
    public class TokenManager: ITokenManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<TokenManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly ITokenRepositories _tokenRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<TokenRequestWrapper, TokenSaveRequest> _tokenSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public TokenManager(ILogger<TokenManager> logger,
            ITokenRepositories tokenRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<TokenRequestWrapper, TokenSaveRequest> tokenSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _tokenRepository = tokenRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _tokenSaveRequestMapper = tokenSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddTokenAsync(TokenRequest request)
        {
            try
            {
                var TokenSaveRequest = _tokenSaveRequestMapper.Map(new TokenRequestWrapper { Request = request });

                var userSaveResponse = await _tokenRepository.SaveTokenAsync(TokenSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdateTokenAsync(TokenRequest request)
        {
            try
            {

                var TokenUpdateRequest = _tokenSaveRequestMapper.Map(new TokenRequestWrapper { Request = request });

                var TokenResponse = await _tokenRepository.UpdateTokenAsync(TokenUpdateRequest);

                return _serviceResponseMapper.Map(TokenResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllTokenAsync()
        {
            try
            {
                var TokenResponse = await _tokenRepository.GetAllTokenAsync();
                return _serviceResponseMapper.Map(TokenResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewTokenAsync(TokenRequest request)
        {
            try
            {
                var TokenDetail = await _tokenRepository.GetTokenDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(TokenDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteTokenAsync(TokenRequest userequest)
        {
            try
            {
                var result = await _tokenRepository.DeleteTokenAsync(userequest.Attributes);
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
