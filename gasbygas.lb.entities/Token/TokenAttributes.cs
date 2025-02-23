using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Token
{
    public class TokenAttributes
    {
        public int TokenID { get; set; }
        public int RequestID { get; set; }
        public int? ParentTokenID { get; set; }
        public int UserID { get; set; }
        public int GasQTY { get; set; }
        public string GasType { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
        public DateTime PurchaseStartDate { get; set; }
        public DateTime PurchaseEndDate { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime TokenReturnDate { get; set; }
        public string TokenStatus { get; set; }
        public int? ReturnEmptyQTY { get; set; }
        public string EmptyGasStatus { get; set; }
        public string ReallocatedBy { get; set; }
        public string TokenNumber { get; set; }
    }
}
