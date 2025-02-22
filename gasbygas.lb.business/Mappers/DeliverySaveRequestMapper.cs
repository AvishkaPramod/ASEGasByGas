using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class DeliverySaveRequestMapper: IMapper<DeliveryRequestWrapper, DeliverySaveRequest>
    {
        public DeliverySaveRequestMapper() { }

        public DeliverySaveRequest Map(DeliveryRequestWrapper input)
        {
            return new DeliverySaveRequest()
            {
                DeliveryID = input.Request.Attributes.DeliveryID,
                StockID = input.Request.Attributes.StockID,
               // OutletID = input.Request.Attributes.OutletID,
                UserID = input.Request.Attributes.UserID,
                GasType = input.Request.Attributes.GasType,
                FullCylinderCount = input.Request.Attributes.FullCylinderCount,
                GasStockDeliveryDate = DateTime.Now,
                ArrivalAtOutlet = DateTime.Now,
                DeliveryStatus = input.Request.Attributes.DeliveryStatus,
                OutletRecipient = input.Request.Attributes.OutletRecipient,
                EmptyCylinderCount = input.Request.Attributes.EmptyCylinderCount,
                EmptyCylinderDeliveryDate = input.Request.Attributes.EmptyCylinderDeliveryDate,
                ArrivalAtGasStock = DateTime.Now,
                ReturnStatus = input.Request.Attributes.ReturnStatus,
                StockRecipient = input.Request.Attributes.StockRecipient,
                OutletStockID = input.Request.Attributes.OutletStockID

            };
        }
    }
}
