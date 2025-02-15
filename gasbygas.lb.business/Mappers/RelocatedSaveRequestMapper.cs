using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Relocated;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class RelocatedSaveRequestMapper: IMapper<RelocatedRequestWrapper, RelocatedSaveRequest>
    {
        public RelocatedSaveRequestMapper() { }

        public RelocatedSaveRequest Map(RelocatedRequestWrapper input)
        {
            return new RelocatedSaveRequest()
            {
                RelocateID = input.Request.Attributes.RelocateID,
                OldTokenID = input.Request.Attributes.OldTokenID,
                NewTokenID = input.Request.Attributes.NewTokenID,
                OldRequestID = input.Request.Attributes.OldRequestID,
                NewRequestID = input.Request.Attributes.NewRequestID,
                RelocationDate = input.Request.Attributes.RelocationDate,
                RelocationStatus = input.Request.Attributes.RelocationStatus,

            };
        }
    }
}
