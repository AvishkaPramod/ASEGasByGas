using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Outlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface IDeliveryRepositories
    {
        // Add 
        Task<DeliveryResponse> SaveDeliveryAsync(DeliverySaveRequest request);

        //Update 
        Task<DeliveryResponse> UpdateDeliveryAsync(DeliverySaveRequest request);

        //List 
        Task<List<DeliveryResponse>> GetAllDeliveryAsync();

        //View  
        Task<DeliveryResponse> GetDeliveryDetailAsync(DeliveryAttributes request);

        //Delete  
        Task<DeliveryResponse> DeleteDeliveryAsync(DeliveryAttributes request);
    }
}
