using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface IGasRequestManager
    {
        //Add 
        Task<ResponseBase> AddGasRequestAsync(GasRequestRequest request);

        //update 
        Task<ResponseBase> UpdateGasRequestAsync(GasRequestRequest request);

        //list 
        Task<ResponseBase> GetAllGasRequestAsync();

        //View 
        Task<ResponseBase> ViewGasRequestAsync(GasRequestRequest request);

        //Delete 
        Task<ResponseBase> DeleteGasRequestAsync(GasRequestRequest request);
    }
}
