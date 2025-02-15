using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Relocated
{
    public class RelocatedAttributes
    {
        public int RelocateID { get; set; }
        public int OldTokenID { get; set; }
        public int? NewTokenID { get; set; }
        public int OldRequestID { get; set; }
        public int? NewRequestID { get; set; }
        public DateTime RelocationDate { get; set; }
        public string RelocationStatus { get; set; }
    }
}
