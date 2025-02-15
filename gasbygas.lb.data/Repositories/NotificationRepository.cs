using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Notification;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.shared.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.data.Repositories
{
    public class NotificationRepository: INotificationRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<NotificationRepository> _logger;

        //Constructor
        public NotificationRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<NotificationRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<NotificationResponse> SaveNotificationAsync(NotificationSaveRequest request)
        {
            try
            {
                var NotificationDetails = _entityMapper.Map<NotificationSaveRequest, notification>(request);
                var NotificationSaveObj = _gasBygasContext.notifications.Add(NotificationDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<notification, NotificationResponse>(NotificationSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<NotificationResponse> UpdateNotificationAsync(NotificationSaveRequest request)
        {
            try
            {
                var Notification = await _gasBygasContext.notifications.FirstOrDefaultAsync(i => i.NotificationID == request.NotificationID);
                Notification.TokenID = request.TokenID;
                Notification.UserID = request.UserID;
                Notification.CustomerID = request.CustomerID;
                Notification.NotificationType = request.NotificationType;
                Notification.Message = request.Message;
                Notification.DateSent = request.DateSent;
                Notification.NotificationStatus = request.NotificationStatus;
                Notification.Reference = request.Reference;


                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<notification, NotificationResponse>(Notification);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<NotificationResponse>> GetAllNotificationAsync()
        {
            try
            {
                var Notifications = await _gasBygasContext.notifications
                .Select(u => new NotificationResponse
                {
                    NotificationID = u.NotificationID,
                    TokenID = u.TokenID,
                    UserID = u.UserID,
                    CustomerID = u.CustomerID,
                    NotificationType = u.NotificationType,
                    Message = u.Message,
                    DateSent = u.DateSent,
                    NotificationStatus = u.NotificationStatus,
                    Reference = u.Reference

                }).ToListAsync();

                return Notifications;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<NotificationResponse> GetNotificationDetailAsync(NotificationAttributes request)
        {
            try
            {
                var Notification = await _gasBygasContext.notifications
                    .Where(u => u.NotificationID == request.NotificationID)
                    .Select(u => new NotificationResponse
                    {
                        NotificationID = u.NotificationID,
                        TokenID = u.TokenID,
                        UserID = u.UserID,
                        CustomerID = u.CustomerID,
                        NotificationType = u.NotificationType,
                        Message = u.Message,
                        DateSent = u.DateSent,
                        NotificationStatus = u.NotificationStatus,
                        Reference = u.Reference,


                    }).FirstOrDefaultAsync();

                return Notification;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<NotificationResponse> DeleteNotificationAsync(NotificationAttributes request)
        {
            try
            {
                var NotificationObj = await _gasBygasContext.notifications.FirstOrDefaultAsync(x => x.NotificationID == request.NotificationID);
                _gasBygasContext.Remove(NotificationObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<notification, NotificationResponse>(NotificationObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
