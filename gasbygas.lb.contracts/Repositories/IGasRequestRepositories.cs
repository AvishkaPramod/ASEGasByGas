using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.GasStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IGasRequestRepositories
    {
        //Add  
        Task<GasRequestResponse> SaveGasRequestAsync(GasRequestSaveRequest request);
        
        //Update GasStock
        Task<GasRequestResponse> UpdateGasRequestAsync(GasRequestSaveRequest request);

        //List 
        Task<List<GasRequestResponse>> GetAllGasRequestAsync();

        //View 
        Task<GasRequestResponse> GetGasRequestDetailAsync(GasRequestAttributes request);

        //Delete
        Task<GasRequestResponse> DeleteGasRequestAsync(GasRequestAttributes request);
    }
}
