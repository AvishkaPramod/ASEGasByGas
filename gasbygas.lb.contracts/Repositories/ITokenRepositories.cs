using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface ITokenRepositories
    {
        //Add  
        Task<TokenResponse> SaveTokenAsync(TokenSaveRequest request);

        //Update  
        Task<TokenResponse> UpdateTokenAsync(TokenSaveRequest request);

        //List 
        Task<List<TokenResponse>> GetAllTokenAsync();

        //View 
        Task<TokenResponse> GetTokenDetailAsync(TokenAttributes request);

        //Delete
        Task<TokenResponse> DeleteTokenAsync(TokenAttributes request);
    }
}
