using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels.Administrator;
using DeNew.Services.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Route("/login")]
        public IActionResult Index()
        {
            return View("View");
        }

        [Route("/login/do")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginData)
        {
            if (ModelState.IsValid)
            {
                var user = _loginService.MakeLoginAttempt(loginData);
                if (user != null)
                {
                    await Authenticate(user.Login);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return View("View", loginData);
            }

            return Redirect($"/");
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}