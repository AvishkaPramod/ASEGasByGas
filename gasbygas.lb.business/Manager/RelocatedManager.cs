using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Relocated;
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
    public class RelocatedManager: IRelocatedManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<RelocatedManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly IRelocatedRepositories _relocatedRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<RelocatedRequestWrapper, RelocatedSaveRequest> _relocatedSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public RelocatedManager(ILogger<RelocatedManager> logger,
            IRelocatedRepositories relocatedRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<RelocatedRequestWrapper, RelocatedSaveRequest> relocatedSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _relocatedRepository = relocatedRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _relocatedSaveRequestMapper = relocatedSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddRelocatedAsync(RelocatedRequest request)
        {
            try
            {
                var RelocatedSaveRequest = _relocatedSaveRequestMapper.Map(new RelocatedRequestWrapper { Request = request });

                var userSaveResponse = await _relocatedRepository.SaveRelocatedAsync(RelocatedSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdateRelocatedAsync(RelocatedRequest request)
        {
            try
            {

                var RelocatedUpdateRequest = _relocatedSaveRequestMapper.Map(new RelocatedRequestWrapper { Request = request });

                var RelocatedResponse = await _relocatedRepository.UpdateRelocatedAsync(RelocatedUpdateRequest);

                return _serviceResponseMapper.Map(RelocatedResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllRelocatedAsync()
        {
            try
            {
                var RelocatedResponse = await _relocatedRepository.GetAllRelocatedAsync();
                return _serviceResponseMapper.Map(RelocatedResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewRelocatedAsync(RelocatedRequest request)
        {
            try
            {
                var RelocatedDetail = await _relocatedRepository.GetRelocatedDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(RelocatedDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteRelocatedAsync(RelocatedRequest userequest)
        {
            try
            {
                var result = await _relocatedRepository.DeleteRelocatedAsync(userequest.Attributes);
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
