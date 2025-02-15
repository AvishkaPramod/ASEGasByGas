using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Payment
{
    public class PaymentSaveRequest
    {
        public int PaymentID { get; set; }
        public int TokenID { get; set; }
        public string Status { get; set; }
        public string Bank { get; set; }
        public string PaymentType { get; set; }
        public string AccountNumber { get; set; }
        public decimal? Price { get; set; }
        public string Branch { get; set; }
    }
}
