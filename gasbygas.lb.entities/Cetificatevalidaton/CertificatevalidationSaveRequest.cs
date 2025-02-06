using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Cetificatevalidaton
{
    public class CertificatevalidationSaveRequest
    {
        public int CertificateValidationID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public byte[] CertificateFile { get; set; }
        public string CertificateStatus { get; set; }
        public string ValidationStatus { get; set; }
        public string ValidationDate { get; set; }
    }
}
