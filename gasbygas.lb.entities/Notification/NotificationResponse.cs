using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Notification
{
    public class NotificationResponse
    {
        public int NotificationID { get; set; }
        public int TokenID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime? DateSent { get; set; }
        public string NotificationStatus { get; set; }
        public string Reference { get; set; }
    }
}
