using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.DataAccess.Entities;

namespace Web.Data.Entities
{
    public class User
    {
        [Key]
        public Int64 UserId { get; set; }
        [Required(ErrorMessage ="必填")]
        public string Name { get; set; }

        [Required(ErrorMessage ="必填")]
        [DataType(DataType.Password,ErrorMessage ="请输入正确的密码格式")]
        [MinLength(6,ErrorMessage ="不得少于 6 个字")]
        public string Password { get; set; }
        public ICollection<User_Role> User_Roles { get; set; }
    }
}
