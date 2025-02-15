using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IPaymentRepositories
    {
        // Add 
        Task<PaymentResponse> SavePaymentAsync(PaymentSaveRequest request);

        //Update 
        Task<PaymentResponse> UpdatePaymentAsync(PaymentSaveRequest request);

        //List 
        Task<List<PaymentResponse>> GetAllPaymentAsync();

        //View  
        Task<PaymentResponse> GetPaymentDetailAsync(PaymentAttributes request);

        //Delete  
        Task<PaymentResponse> DeletePaymentAsync(PaymentAttributes request);
    }
}
