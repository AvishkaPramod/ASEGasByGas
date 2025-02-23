using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.Token
{
    public class TokenRequest
    {
        public string Action {  get; set; }

        public TokenAttributes Attributes { get; set; }
    }
}
