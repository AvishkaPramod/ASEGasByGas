using gasbygas.lb.entities.Notification;
using gasbygas.lb.entities.Outlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface INotificationRepositories
    {
        // Add 
        Task<NotificationResponse> SaveNotificationAsync(NotificationSaveRequest request);

        //Update 
        Task<NotificationResponse> UpdateNotificationAsync(NotificationSaveRequest request);

        //List 
        Task<List<NotificationResponse>> GetAllNotificationAsync();

        //View  
        Task<NotificationResponse> GetNotificationDetailAsync(NotificationAttributes request);

        //Delete  
        Task<NotificationResponse> DeleteNotificationAsync(NotificationAttributes request);
    }
}
