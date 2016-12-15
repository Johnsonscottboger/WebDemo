using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedMan.Data.IRepository;
using Web.Data.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Demo.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> _userRepo;
        public UserController(IRepository<User> userRepo)
        {
            this._userRepo = userRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = new User()
            {
                Name = "User1"
            };
            _userRepo.Add(user);

            var userAdded = _userRepo.Find(p => p.Name == user.Name);

            return View();
        }
    }
}
