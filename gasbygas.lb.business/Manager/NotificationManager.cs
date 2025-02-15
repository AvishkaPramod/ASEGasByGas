using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.Notification;
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
    public class NotificationManager: INotificationManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<NotificationManager> _logger;

        /// <summary>
        /// repository
        /// </summary>
        private readonly INotificationRepositories _notificationRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The  save mapper
        /// </summary>
        private readonly IMapper<NotificationRequestWrapper, NotificationSaveRequest> _notificationSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public NotificationManager(ILogger<NotificationManager> logger,
            INotificationRepositories notificationRepositories,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<NotificationRequestWrapper, NotificationSaveRequest> notificationSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _notificationRepository = notificationRepositories;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _notificationSaveRequestMapper = notificationSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add  
        public async Task<ResponseBase> AddNotificationAsync(NotificationRequest request)
        {
            try
            {
                var NotificationSaveRequest = _notificationSaveRequestMapper.Map(new NotificationRequestWrapper { Request = request });

                var userSaveResponse = await _notificationRepository.SaveNotificationAsync(NotificationSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update  
        public async Task<ResponseBase> UpdateNotificationAsync(NotificationRequest request)
        {
            try
            {

                var NotificationUpdateRequest = _notificationSaveRequestMapper.Map(new NotificationRequestWrapper { Request = request });

                var NotificationResponse = await _notificationRepository.UpdateNotificationAsync(NotificationUpdateRequest);

                return _serviceResponseMapper.Map(NotificationResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllNotificationAsync()
        {
            try
            {
                var NotificationResponse = await _notificationRepository.GetAllNotificationAsync();
                return _serviceResponseMapper.Map(NotificationResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewNotificationAsync(NotificationRequest request)
        {
            try
            {
                var NotificationDetail = await _notificationRepository.GetNotificationDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(NotificationDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteNotificationAsync(NotificationRequest userequest)
        {
            try
            {
                var result = await _notificationRepository.DeleteNotificationAsync(userequest.Attributes);
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
