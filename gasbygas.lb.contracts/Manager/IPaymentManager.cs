using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Payment;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface IPaymentManager
    {
        //Add  
        Task<ResponseBase> AddPaymentAsync(PaymentRequest request);

        //update  
        Task<ResponseBase> UpdatePaymentAsync(PaymentRequest request);

        //list  
        Task<ResponseBase> GetAllPaymentAsync();

        //View  
        Task<ResponseBase> ViewPaymentAsync(PaymentRequest request);

        //Delete  
        Task<ResponseBase> DeletePaymentAsync(PaymentRequest request);
    }
}
