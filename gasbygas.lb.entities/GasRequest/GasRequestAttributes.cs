using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.GasRequest
{
    public class GasRequestAttributes
    {
        public int RequestID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public int OutletID { get; set; }
        public string RequestCategory { get; set; }
        public int GasQTY { get; set; }
        public string GasType { get; set; }
        public DateTime GasNeedDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? UpdatedDate { get; set; }


      //  public List<Token> Tokens { get; set; }  

    }

    public class Token
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
