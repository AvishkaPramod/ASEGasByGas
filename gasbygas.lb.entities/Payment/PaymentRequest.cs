using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Payment
{
    public class PaymentRequest
    {
        public string Action {  get; set; }
        public PaymentAttributes Attributes { get; set; }
    }
}
