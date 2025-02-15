using gasbygas.lb.entities.Outlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Delivery
{
    public class DeliveryRequest
    {
        public string Action { get; set; }
        public DeliveryAttributes Attributes { get; set; }
    }
}
