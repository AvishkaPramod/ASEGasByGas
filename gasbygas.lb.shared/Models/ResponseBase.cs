using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.shared.Models
{
    public class ResponseBase
    {/// <summary>
     /// Gets or sets IsSuccess.
     /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        public dynamic Result { get; set; }

        /// <summary>
        /// Gets or sets Error.
        /// </summary>
        public ResponseMessage Error { get; set; }
    }
}
