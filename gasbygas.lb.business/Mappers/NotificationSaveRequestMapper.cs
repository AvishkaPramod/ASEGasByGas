using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.Notification;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class NotificationSaveRequestMapper: IMapper<NotificationRequestWrapper, NotificationSaveRequest>
    {
        public NotificationSaveRequestMapper() { }

        public NotificationSaveRequest Map(NotificationRequestWrapper input)
        {
            return new NotificationSaveRequest()
            {
                NotificationID = input.Request.Attributes.NotificationID,
                TokenID = input.Request.Attributes.TokenID,
                UserID = input.Request.Attributes.UserID,
                CustomerID = input.Request.Attributes.CustomerID,
                NotificationType = input.Request.Attributes.NotificationType,
                Message = input.Request.Attributes.Message,
                DateSent = DateTime.Now,
                NotificationStatus = input.Request.Attributes.NotificationStatus,
                Reference = input.Request.Attributes.Reference
            };
        }
    }
}
