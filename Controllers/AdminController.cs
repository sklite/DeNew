using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeNew.Services.Admin;
using Microsoft.AspNetCore.Mvc;

namespace DeNew.Controllers
{
    public class AdminController : Controller
    {
        private ILoginService _loginService;
        public AdminController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [Route("/login")]
        public IActionResult Index()
        {
            return View("View");
        }

        [Route("/login/do")]
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            return Redirect($"/");
        }

    }
}