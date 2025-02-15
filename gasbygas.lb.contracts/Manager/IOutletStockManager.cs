using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.OutletStock;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface IOutletStockManager
    {
        //Add  
        Task<ResponseBase> AddOutletStockAsync(OutletStockRequest request);

        //update  
        Task<ResponseBase> UpdateOutletStockAsync(OutletStockRequest request);

        //list  
        Task<ResponseBase> GetAllOutletStockAsync();

        //View  
        Task<ResponseBase> ViewOutletStockAsync(OutletStockRequest request);

        //Delete  
        Task<ResponseBase> DeleteOutletStockAsync(OutletStockRequest request);
    }
}
