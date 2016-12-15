using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.DataAccess.Entities;

namespace Web.Data.Entities
{
    public class Role
    {
        [Key]
        public Int64 RoleId { get; set; }

        [Required(ErrorMessage ="必填")]
        [MinLength(3,ErrorMessage ="不得少于 3 个字")]
        public string RoleName { get; set; }

        public ICollection<User_Role> User_Roles { get; set; }
    }
}
