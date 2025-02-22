using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Delivery
{
    public class DeliveryResponse
    {
        public int DeliveryID { get; set; }
        public int StockID { get; set; }
        //public int OutletID { get; set; }
        public int UserID { get; set; }
        public string GasType { get; set; }
        public int? FullCylinderCount { get; set; }
        public DateTime? GasStockDeliveryDate { get; set; }
        public DateTime? ArrivalAtOutlet { get; set; }
        public string DeliveryStatus { get; set; }
        public string OutletRecipient { get; set; }
        public int? EmptyCylinderCount { get; set; }
        public DateTime? EmptyCylinderDeliveryDate { get; set; }
        public DateTime? ArrivalAtGasStock { get; set; }
        public string ReturnStatus { get; set; }
        public string StockRecipient { get; set; }
        public int? OutletStockID { get; set; }
    }
}
