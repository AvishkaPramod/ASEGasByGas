using gasbygas.lb.entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.OutletStock
{
    public class OutletStockRequest
    {
        public string Action { get; set; }
        public OutletStockAttributes Attributes { get; set; }
    }
}
