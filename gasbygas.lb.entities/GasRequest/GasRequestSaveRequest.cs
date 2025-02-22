using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.GasRequest
{
    public class GasRequestSaveRequest: BaseEntity
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


      //  public List<Token> Tokens { get; set; } = new List<Token>();


    }
}
