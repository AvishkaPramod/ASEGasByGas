using AutoMapper;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public  class CustomerSaveRequestMapper: IMapper<CustomerRequestWrapper, CustomerSaveRequest>
    {
        public CustomerSaveRequestMapper()
        {

        }   
        
        public CustomerSaveRequest Map(CustomerRequestWrapper input)
        {
            return new CustomerSaveRequest()
            {
                CustomerId = input.Request.Attributes.CustomerId,
                FirstName = input.Request.Attributes.FirstName,
                LastName = input.Request.Attributes.LastName,
                Nic = input.Request.Attributes.Nic,
                Address = input.Request.Attributes.Address,
                ContactNumber = input.Request.Attributes.ContactNumber,
                Email = input.Request.Attributes.Email,
                CustomerType = input.Request.Attributes.CustomerType,
                RegistrationDate = input.Request.Attributes.RegistrationDate,
                Status = input.Request.Attributes.Status,
                UserName = input.Request.Attributes.UserName,
                Password = input.Request.Attributes.Password,
                UpdatedDate = DateTime.Now,
                UpdatedBy = input.Request.Attributes.UpdatedBy
            };
        }
    }

   
}
