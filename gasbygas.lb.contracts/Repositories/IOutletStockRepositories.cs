using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.OutletStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IOutletStockRepositories
    {
        // Add 
        Task<OutletStockResponse> SaveOutletStockAsync(OutletStockSaveRequest request);

        //Update 
        Task<OutletStockResponse> UpdateOutletStockAsync(OutletStockSaveRequest request);

        //List 
        Task<List<OutletStockResponse>> GetAllOutletStockAsync();

        //View  
        Task<OutletStockResponse> GetOutletStockDetailAsync(OutletStockAttributes request);

        //Delete  
        Task<OutletStockResponse> DeleteOutletStockAsync(OutletStockAttributes request);
    }
}
