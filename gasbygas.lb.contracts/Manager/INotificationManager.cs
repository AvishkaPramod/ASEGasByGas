using gasbygas.lb.entities.Notification;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface INotificationManager
    {
        //Add  
        Task<ResponseBase> AddNotificationAsync(NotificationRequest request);

        //update  
        Task<ResponseBase> UpdateNotificationAsync(NotificationRequest request);

        //list  
        Task<ResponseBase> GetAllNotificationAsync();

        //View  
        Task<ResponseBase> ViewNotificationAsync(NotificationRequest request);

        //Delete  
        Task<ResponseBase> DeleteNotificationAsync(NotificationRequest request);
    }
}
