using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.shared.Models
{
    public class ResponseMessage
    {
        /// <summary>
        /// Gets or sets the message code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the message type
        /// </summary>
        public string MessageType { get; set; }
    }
}
