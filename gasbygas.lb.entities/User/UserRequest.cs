using gasbygas.lb.entities.GasStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.User
{
    public class UserRequest
    {
        public string Action { get; set; }
        public UserAttributes Attributes { get; set; }
    }
}
