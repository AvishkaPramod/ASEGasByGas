using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.OutletStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IOutletRepositories
    {
        // Add 
        Task<OutletResponse> SaveOutletAsync(OutletSaveRequest request);

        //Update 
        Task<OutletResponse> UpdateOutletAsync(OutletSaveRequest request);

        //List 
        Task<List<OutletResponse>> GetAllOutletAsync();

        //View  
        Task<OutletResponse> GetOutletDetailAsync(OutletAttributes request);

        //Delete  
        Task<OutletResponse> DeleteOutletAsync(OutletAttributes request);
    }
}
