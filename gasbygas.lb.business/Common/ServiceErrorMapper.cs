using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Common
{
    /// <summary>
    /// ServiceErrorMapper
    /// </summary>
    /// <seealso cref="gasbygas.lb.shared.Contracts.IMapper{gasbygas.lb.shared.Models.ResponseMessage, gasbygas.lb.shared.Models.ResponseBase}" />
    public class ServiceErrorMapper: IMapper<ResponseMessage, ResponseBase>
    {
        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public ResponseBase Map(ResponseMessage input) => new ResponseBase
        {
            IsSuccess = false,
            Error = input
        };
    }
}
