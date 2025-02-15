using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Relocated;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface IRelocatedManager
    {
        //Add  
        Task<ResponseBase> AddRelocatedAsync(RelocatedRequest request);

        //update  
        Task<ResponseBase> UpdateRelocatedAsync(RelocatedRequest request);

        //list  
        Task<ResponseBase> GetAllRelocatedAsync();

        //View  
        Task<ResponseBase> ViewRelocatedAsync(RelocatedRequest request);

        //Delete  
        Task<ResponseBase> DeleteRelocatedAsync(RelocatedRequest request);
    }
}
