using gasbygas.lb.entities.Customer;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface ICustomerManager
    {
        //Add customer
        Task<ResponseBase> AddCustomerAsync(CustomerRequest request);

        //update customer
        Task<ResponseBase> UpdateCustomerAsync(CustomerRequest request);

        //list customer
        Task<ResponseBase> GetAllCustomerAsync();

        //View Customer
        Task<ResponseBase> ViewCustomerAsync(CustomerRequest request);

        //Delete Customer
        Task<ResponseBase> DeleteCustomerAsync(CustomerRequest request);
    }
}
