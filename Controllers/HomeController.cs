using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DeNew.Models;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;
using DeNew.Services;
using DeNew.Services.Pages;
using DeNew.Settings;

namespace DeNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IPageConverterService _pageConverterService;
        public HomeController(IPageService pageService, IPageConverterService converter)
        {
            _pageService = pageService;
            _pageConverterService = converter;
        }
        public IActionResult Index()
        {
            var mainPage = _pageService.GetPage();
            var mainPageVm = _pageConverterService.ConvertPage(mainPage);
            return View("IndexNew", mainPageVm);
        }

        //Support older links
        [Route("Category/{id}")]
        public ActionResult Index(int id)
        {
            return Redirect($"/main/{id}");
        }

        [Route("Category/{catId}/{subCatId}")]
        public ActionResult Index(int id, int subCatId)
        {
            return Redirect($"/main/{id}/{subCatId}");
        }


        [Route("main/{category}")]
        public IActionResult Page(string category)
        {
            if (string.IsNullOrEmpty(category))
                return RedirectToAction("Index");
            var page = _pageService.GetPage(category);
            var pageVm = _pageConverterService.ConvertPage(page);
            return View("IndexNew", pageVm);

        }

        [Route("main/{category}/{subcategory}")]
        public IActionResult Page(string category, string subcategory)
        {
            var page = _pageService.GetPage(category, subcategory);
            var pageVm = _pageConverterService.ConvertPage(page);
            return View("IndexNew", pageVm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

         //   ViewData["Message"] += _service.Send();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult ContactUs(FooterViewModel footerViewModel)
        {
            ViewBag.Message = "Данные были заполнены неверно";
            if (!ModelState.IsValid)
                return View();


            //var request = Mapper.Map<UserRequest>(footerViewModel);

            //var userRequestBl = new UserRequestBl();

            //userRequestBl.AddRequest(request);

            ViewBag.BackLink = Request.Headers["Referer"].ToString();;
            ViewBag.TimetoRedirect = VariablesSettingsConfig.TIME_TO_REDIRECT;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
