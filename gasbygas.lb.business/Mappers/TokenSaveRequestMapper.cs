using AutoMapper;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Token;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class TokenSaveRequestMapper: IMapper<TokenRequestWrapper, TokenSaveRequest>
    {
        public TokenSaveRequestMapper() { }

        public TokenSaveRequest Map(TokenRequestWrapper input)
        {
            return new TokenSaveRequest()
            {
                TokenID = input.Request.Attributes.TokenID,
                RequestID = input.Request.Attributes.RequestID,
                ParentTokenID = input.Request.Attributes.ParentTokenID,
                UserID = input.Request.Attributes.UserID,
                GasQTY = input.Request.Attributes.GasQTY,
                GasType = input.Request.Attributes.GasType,
                UnitPrice = input.Request.Attributes.UnitPrice,
                Total = input.Request.Attributes.Total,
                PurchaseStartDate = DateTime.UtcNow,
                PurchaseEndDate = DateTime.UtcNow.AddDays(14),
                PickupDate = input.Request.Attributes.PickupDate,
                TokenReturnDate = DateTime.UtcNow.AddDays(15),
                TokenStatus = input.Request.Attributes.TokenStatus,
                ReturnEmptyQTY = input.Request.Attributes.ReturnEmptyQTY,
                EmptyGasStatus = input.Request.Attributes.EmptyGasStatus,
                ReallocatedBy = input.Request.Attributes.ReallocatedBy,
                TokenNumber = input.Request.Attributes.TokenNumber,

            };
        }
    }
}
