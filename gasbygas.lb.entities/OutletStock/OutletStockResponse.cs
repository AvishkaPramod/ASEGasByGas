using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.OutletStock
{
    public class OutletStockResponse
    {
        public int OutletStockID { get; set; }
        public string GasType { get; set; }
        public int? EmptyGaSQTY { get; set; }
        public int? GasStockLevel { get; set; }
        public int? ReceivingQTY { get; set; }
        public DateTime? ReceivingDate { get; set; }
        public int? EmptyReturnQTY { get; set; }
        public int? OutletID { get; set; }
    }
}
