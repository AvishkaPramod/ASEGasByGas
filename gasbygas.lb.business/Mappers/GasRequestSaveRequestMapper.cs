using gasbygas.lb.business.Wrappers;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class GasRequestSaveRequestMapper: IMapper<GasRequestRequestWrapper, GasRequestSaveRequest>
    {
        public GasRequestSaveRequestMapper() { }

        public GasRequestSaveRequest Map(GasRequestRequestWrapper input)
        {
            return new GasRequestSaveRequest()
            {
                RequestID = input.Request.Attributes.RequestID,
                CustomerID = input.Request.Attributes.CustomerID,
                UserID = input.Request.Attributes.UserID,
                OutletID = input.Request.Attributes.OutletID,
                RequestCategory = input.Request.Attributes.RequestCategory,
                GasQTY = input.Request.Attributes.GasQTY,
                GasType = input.Request.Attributes.GasType,
                GasNeedDate = DateTime.Now,
                RequestDate = DateTime.Now,
                RequestStatus = input.Request.Attributes.RequestStatus,
                UpdatedDate = DateTime.Now
                /*Tokens = input.Request.Attributes.Tokens.Select(t => new Token
                {
                    TokenID = t.TokenID,
                    RequestID = t.RequestID,
                    ParentTokenID = t.ParentTokenID,
                    UserID = t.UserID,
                    TokenNumber = t.TokenNumber,
                    GasQTY = t.GasQTY,
                    GasType = t.GasType,
                    UnitPrice = t.UnitPrice,
                    Total = t.Total,
                    PurchaseStartDate = DateTime.UtcNow,
                    PurchaseEndDate = DateTime.UtcNow.AddDays(14),
                    PickupDate = DateTime.UtcNow.AddDays(00),
                    TokenReturnDate = DateTime.UtcNow.AddDays(16),
                    TokenStatus = t.TokenStatus,
                    ReturnEmptyQTY = t.ReturnEmptyQTY,
                    EmptyGasStatus = t.EmptyGasStatus,
                    ReallocatedBy = t.ReallocatedBy
                    
                }).ToList()*/
                
            };
        }
    }
}
