using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Relocated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IRelocatedRepositories
    {
        // Add 
        Task<RelocatedResponse> SaveRelocatedAsync(RelocatedSaveRequest request);

        //Update 
        Task<RelocatedResponse> UpdateRelocatedAsync(RelocatedSaveRequest request);

        //List 
        Task<List<RelocatedResponse>> GetAllRelocatedAsync();

        //View  
        Task<RelocatedResponse> GetRelocatedDetailAsync(RelocatedAttributes request);

        //Delete  
        Task<RelocatedResponse> DeleteRelocatedAsync(RelocatedAttributes request);
    }
}
