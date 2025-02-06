using gasbygas.lb.business.Wrappers;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class UserSaveRequestMapper: IMapper<UserRequestWrapper, UserSaveRequest>
    {
        public UserSaveRequestMapper() 
        { }

        public UserSaveRequest Map(UserRequestWrapper input)
        {
            return new UserSaveRequest()
            {
                UserID = input.Request.Attributes.UserID,
                OutletID = input.Request.Attributes.OutletID,
                UserName = input.Request.Attributes.UserName,
                Password = input.Request.Attributes.Password,
                FirstName = input.Request.Attributes.FirstName,
                LastName = input.Request.Attributes.LastName,
                Address = input.Request.Attributes.Address,
                Email = input.Request.Attributes.Email,
                Status = input.Request.Attributes.Status,
                UserRole = input.Request.Attributes.UserRole,
                CreatedDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = input.Request.Attributes.CreatedBy,
                UpdatedBy = input.Request.Attributes.UpdatedBy
            };
        }
    }
}
