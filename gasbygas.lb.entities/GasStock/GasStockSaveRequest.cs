using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.GasStock
{
    public class GasStockSaveRequest: BaseEntity
    {
        public int StockID { get; set; }
        public string GasType { get; set; }
        public int DistributedQTY { get; set; }
        public int? QuantityAvailable { get; set; }
        public double? UnitPrice { get; set; }
        public int? StockQuantity { get; set; }
        public string StockStatus { get; set; }
        public int? RecoveredemptyQTY { get; set; }
        public int? UserID { get; set; }
    }
}
