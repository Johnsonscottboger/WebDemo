using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data.Entities;

namespace Web.DataAccess.Entities
{
    public class User_Role
    {
        public Int64 UserId { get; set; }
        public User User { get; set; }

        public Int64 RoleId { get; set; }
        public Role Role { get; set; }
    }
}
