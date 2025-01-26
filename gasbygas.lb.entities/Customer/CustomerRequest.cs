using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Customer
{
    public class CustomerRequest
    {
        public string Action {  get; set; }
        public CustomerAttributes Attributes { get; set; }
    }
}
