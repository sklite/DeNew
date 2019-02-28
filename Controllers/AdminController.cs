using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;
using DeNew.Models.ViewModels.Administrator;
using DeNew.Services.Admin;
using DeNew.Services.Pages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace DeNew.Controllers
{
    public class AdminController : Controller
    {
        private ILoginService _loginService;
        private IPageManipulator _pageManipulator;
        private IPageConverterService _pageConverterService;
        private IPageRepository _pageRepository;
        public AdminController(ILoginService loginService,
            IPageManipulator pageManipulator, 
            IPageConverterService pageConverterService,
            IPageRepository pageRepository)
        {
            _loginService = loginService;
            _pageManipulator = pageManipulator;
            _pageConverterService = pageConverterService;
            _pageRepository = pageRepository;
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>{new Claim(ClaimsIdentity.DefaultNameClaimType, userName)};
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
                var user = await _loginService.MakeLoginAttempt(loginData);
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
        [Authorize]
        public IActionResult CreateNewPage(int parentId = 1)
        {
            var page = _pageManipulator.CreateNewPage(parentId);
            return RedirectToAction("OpenPage", "Home", new { pageId = page.Id});
        }
        //[Route("/delete")]
        [Authorize]
        [HttpPost]
        public JsonResult Delete(int pageId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var obj = new { Message = "Недостаточно прав" };
                return new JsonResult(obj);
            }

            var result = _pageManipulator.DeletePage(pageId, out string message);
            return new JsonResult(new {Deleted = result, Message = message});
        }
        [Authorize]
        [Route("/edit")]
        public IActionResult EditPage(int pageId)
        {
            var page = _pageRepository.GetPageById(pageId);
            var pageVm = _pageConverterService.ConvertPage(page);
            pageVm.CanEdit = User.Identity.IsAuthenticated;
            if (pageId == 1)
                return View("WebsiteEdit", pageVm);
            return View("PageEdit", pageVm);
        }

        [HttpPost]
        public IActionResult Update(PageViewModel pageVm)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var obj = new { Message = "Недостаточно прав" };
                return new JsonResult(obj);
            }

            var pageModel = _pageConverterService.ConvertPageVm(pageVm);
            var result = _pageManipulator.UpdatePage(pageModel, out string message);

            return RedirectToAction("OpenPage", "Home", new {pageId = pageModel.Id});
        }

        public IActionResult ImageBrowser()
        {
            return View();
        }

    }
}