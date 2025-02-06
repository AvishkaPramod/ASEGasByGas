using gasbygas.lb.entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Cetificatevalidaton
{
    public class CertificatevalidationRequest
    {
        public string Action { get; set; }
        public CertificatevalidationAttributes Attributes { get; set; }
    }
}
