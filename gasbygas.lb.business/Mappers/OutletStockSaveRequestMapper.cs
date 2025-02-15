using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.OutletStock;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class OutletStockSaveRequestMapper: IMapper<OutletStockRequestWrapper, OutletStockSaveRequest>
    {
        public OutletStockSaveRequestMapper() { }

        public OutletStockSaveRequest Map(OutletStockRequestWrapper input)
        {
            return new OutletStockSaveRequest()
            {
                OutletStockID = input.Request.Attributes.OutletStockID,
                GasType = input.Request.Attributes.GasType,
                EmptyGaSQTY = input.Request.Attributes.EmptyGaSQTY,
                GasStockLevel = input.Request.Attributes.GasStockLevel,
                ReceivingQTY = input.Request.Attributes.ReceivingQTY,
                ReceivingDate = DateTime.Now,
                EmptyReturnQTY = input.Request.Attributes.EmptyReturnQTY,
                OutletID = input.Request.Attributes.OutletID               

            };
        }
    }


}
