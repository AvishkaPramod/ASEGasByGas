using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface IGasStockManager
    {
        //Add 
        Task<ResponseBase> AddGasStockAsync(GasStockRequest request);

        //update 
        Task<ResponseBase> UpdateGasStockAsync(GasStockRequest request);

        //list 
        Task<ResponseBase> GetAllGasStockAsync();

        //View 
        Task<ResponseBase> ViewGasStockAsync(GasStockRequest request);

        //Delete 
        Task<ResponseBase> DeleteGasStockAsync(GasStockRequest request);
    }
}
