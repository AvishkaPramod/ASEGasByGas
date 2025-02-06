using gasbygas.lb.entities.GasStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IGasStockRepositories
    {
        //Add GasStock
        Task<GasStockResponse> SaveGaasStockAsync(GasStockSaveRequest request);

        //Update GasStock
        Task<GasStockResponse> UpdateGasStockAsync(GasStockSaveRequest request);

        //List 
        Task<List<GasStockResponse>> GetAllGasStockAsync();

        //View 
        Task<GasStockResponse> GetGasStockDetailAsync(GasStockAttributes request);

        //Delete
        Task<GasStockResponse> DeleteGasStockAsync(GasStockAttributes request);
    }
}
