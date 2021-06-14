using AtomicSeller.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using AtomicSeller.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using RestSharp;
using System.Threading;
using System.Globalization;

namespace AtomicSeller.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            bool InitData = CreateNew("sessionBag", "HomeControllerIndex");

            if (InitData == false)
            {
                HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);

                //return RedirectToAction("Login", "Account");
                return Redirect("/Account/Login");
            }
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

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GotoDocumentation()
        {
            //var client = WordPress.GetClient("test", "1234");
            string URL = "https://www.atomicseller.com/docs/";
            return Redirect(URL);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GotoSupportTickets()
        {
            //var client = WordPress.GetClient("test", "1234");
            CultureInfo Culture = Thread.CurrentThread.CurrentUICulture;
            string URL = string.Empty;

            if (Culture.Name == "fr-FR")
                URL = "https://fr.support.atomicseller.com";
            else
                URL = "https://en.support.atomicseller.com";
            return Redirect(URL);
        }
    }
}
