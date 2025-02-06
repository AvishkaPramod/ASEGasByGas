using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class GasStockSaveRequestMapper: IMapper<GasStockRequestWrapper, GasStockSaveRequest>
    {
        public GasStockSaveRequestMapper() 
        { }

        public GasStockSaveRequest Map(GasStockRequestWrapper input)
        {
            return new GasStockSaveRequest()
            {
                StockID = input.Request.Attributes.StockID,
                GasType = input.Request.Attributes.GasType,
                DistributedQTY = input.Request.Attributes.DistributedQTY,
                QuantityAvailable = input.Request.Attributes.QuantityAvailable,
                UnitPrice = input.Request.Attributes.UnitPrice,
                StockQuantity = input.Request.Attributes.StockQuantity,
                StockStatus = input.Request.Attributes.StockStatus,
                RecoveredemptyQTY = input.Request.Attributes.RecoveredemptyQTY,
                UserID = input.Request.Attributes.UserID
            };
        }

    }
}
