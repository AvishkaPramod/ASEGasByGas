using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Notification
{
    public class NotificationRequest
    {
        public string Action { get; set; }
        public NotificationAttributes Attributes { get; set; }
    }
}
