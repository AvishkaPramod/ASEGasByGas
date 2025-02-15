using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Customer;
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
    public class OutletManager: IOutletManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<OutletManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly IOutletRepositories _outletRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<OutletRequestWrapper, OutletSaveRequest> _outletSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public OutletManager(ILogger<OutletManager> logger,
            IOutletRepositories outletRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<OutletRequestWrapper, OutletSaveRequest> outletSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _outletRepository = outletRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _outletSaveRequestMapper = outletSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddOutletAsync(OutletRequest request)
        {
            try
            {
                var OutletSaveRequest = _outletSaveRequestMapper.Map(new OutletRequestWrapper { Request = request });

                var userSaveResponse = await _outletRepository.SaveOutletAsync(OutletSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdateOutletAsync(OutletRequest request)
        {
            try
            {

                var OutletUpdateRequest = _outletSaveRequestMapper.Map(new OutletRequestWrapper { Request = request });

                var OutletResponse = await _outletRepository.UpdateOutletAsync(OutletUpdateRequest);

                return _serviceResponseMapper.Map(OutletResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllOutletAsync()
        {
            try
            {
                var OutletResponse = await _outletRepository.GetAllOutletAsync();
                return _serviceResponseMapper.Map(OutletResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewOutletAsync(OutletRequest request)
        {
            try
            {
                var OutletDetail = await _outletRepository.GetOutletDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(OutletDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteOutletAsync(OutletRequest userequest)
        {
            try
            {
                var result = await _outletRepository.DeleteOutletAsync(userequest.Attributes);
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
