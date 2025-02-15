using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Outlet
{
    public class OutletRequest
    {
        public string Action {  get; set; }
        public OutletAttributes Attributes { get; set; }
    }
}
