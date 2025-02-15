using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.OutletStock;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class OutletSaveRequestMapper: IMapper<OutletRequestWrapper, OutletSaveRequest>
    {
        public OutletSaveRequestMapper() { }

        public OutletSaveRequest Map(OutletRequestWrapper input)
        {
            return new OutletSaveRequest()
            {
                OutletID = input.Request.Attributes.OutletID,
                OutletName = input.Request.Attributes.OutletName,
                ContactDetails = input.Request.Attributes.ContactDetails,
                Location = input.Request.Attributes.Location,
                District = input.Request.Attributes.District,
                

            };
        }
    }
}
