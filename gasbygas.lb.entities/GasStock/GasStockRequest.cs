using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.GasStock
{
    public class GasStockRequest
    {
        public string Action { get; set; }
        public GasStockAttributes Attributes { get; set; }
    }
}
