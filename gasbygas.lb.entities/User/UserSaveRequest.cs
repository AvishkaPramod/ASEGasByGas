using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.entities.User
{
    public class UserSaveRequest: BaseEntity
    {
        public int UserID { get; set; }
        public int? OutletID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string UserRole { get; set; }
           
    }
}
