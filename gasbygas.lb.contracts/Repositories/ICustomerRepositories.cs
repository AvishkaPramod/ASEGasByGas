using gasbygas.lb.entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface ICustomerRepositories
    {
        // Add customer
        Task<CustomerResponse> SaveCustomerAsync(CustomerSaveRequest request);

        //Update customer
        Task<CustomerResponse> UpdateCustomerAsync(CustomerSaveRequest request);

        //List Customer
        Task<List<CustomerResponse>> GetAllCutomerAsync();

        //View Customer
        Task<CustomerResponse> GetCustomerDetailAsync(CustomerAttributes request);

        //Delete customer
        Task<CustomerResponse> DeleteCustomerAsync(CustomerAttributes request);
    }
}
