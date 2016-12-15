using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedMan.Data.IRepository;
using Web.Data.Entities;
using Web.DataAccess.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Demo.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> _userRepo;
        private IRepository<Role> _roleRepo;
        private IRepository<User_Role> _userRoleRepo;


        public UserController(
            IRepository<User> userRepo,
            IRepository<Role> roleRepo,
            IRepository<User_Role> userRoleRepo)
        {
            this._userRepo = userRepo;
            this._roleRepo = roleRepo;
            this._userRoleRepo = userRoleRepo;
            
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = new User()
            {
                Name = "User1",
                Password="123456"
            };

            var role = new Role()
            {
                RoleName = "Admin"
            };

            user.User_Roles = new List<User_Role>()
            {
                new User_Role()
                {
                    Role=role
                }
            };


            //_userRepo.Add(user);

            var userAdded = _userRepo.Find(p => p.Name == user.Name);
            var roleAdded = _roleRepo.Find(p => p.RoleName == role.RoleName);
            var user_Roles = _userRoleRepo.FindAll(p => p.UserId == userAdded.UserId);
            
            return View();
        }
    }
}
