    using gasbygas.lb.entities.Delivery;
    using gasbygas.lb.entities.Outlet;
    using gasbygas.lb.shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace gasbygas.lb.contracts.Manager
    {
        public interface IDeliveryManager
        {
            //Add  
            Task<ResponseBase> AddDeliveryAsync(DeliveryRequest request);

            //update  
            Task<ResponseBase> UpdateDeliveryAsync(DeliveryRequest request);

            //list  
            Task<ResponseBase> GetAllDeliveryAsync();

            //View  
            Task<ResponseBase> ViewDeliveryAsync(DeliveryRequest request);

            //Delete  
            Task<ResponseBase> DeleteDeliveryAsync(DeliveryRequest request);
        }
    }
