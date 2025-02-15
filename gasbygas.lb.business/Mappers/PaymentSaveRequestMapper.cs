using AutoMapper;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Payment;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class PaymentSaveRequestMapper : IMapper<PaymentRequestWrapper, PaymentSaveRequest>
    {
        public PaymentSaveRequestMapper() { }

        public PaymentSaveRequest Map(PaymentRequestWrapper input)
        {
            return new PaymentSaveRequest()
            {
                PaymentID = input.Request.Attributes.PaymentID,
                TokenID = input.Request.Attributes.TokenID,
                Status = input.Request.Attributes.Status,
                Bank = input.Request.Attributes.Bank,
                PaymentType = input.Request.Attributes.PaymentType,
                AccountNumber = input.Request.Attributes.AccountNumber,
                Price = input.Request.Attributes.Price,
                Branch = input.Request.Attributes.Branch
            };
        }
            
    }
}
