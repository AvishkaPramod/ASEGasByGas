using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.OutletStock;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface IOutletManager
    {
        //Add  
        Task<ResponseBase> AddOutletAsync(OutletRequest request);

        //update  
        Task<ResponseBase> UpdateOutletAsync(OutletRequest request);

        //list  
        Task<ResponseBase> GetAllOutletAsync();

        //View  
        Task<ResponseBase> ViewOutletAsync(OutletRequest request);

        //Delete  
        Task<ResponseBase> DeleteOutletAsync(OutletRequest request);
    }
}
