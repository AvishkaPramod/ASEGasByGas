using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.Token;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface ITokenManager
    {
        //Add 
        Task<ResponseBase> AddTokenAsync(TokenRequest request);

        //update 
        Task<ResponseBase> UpdateTokenAsync(TokenRequest request);

        //list 
        Task<ResponseBase> GetAllTokenAsync();

        //View 
        Task<ResponseBase> ViewTokenAsync(TokenRequest request);

        //Delete 
        Task<ResponseBase> DeleteTokenAsync(TokenRequest request);
    }
}
