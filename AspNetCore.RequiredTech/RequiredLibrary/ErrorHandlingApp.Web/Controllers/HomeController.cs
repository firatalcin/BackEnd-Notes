using ErrorHandlingApp.Web.Filter;
using ErrorHandlingApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandlingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomHandleExceptionFilterAttribute]
        public IActionResult Index()
        {
            int value1 = 5;
            int value2 = 0;
            int result = value1 / value2;
            return View();
        }

        [CustomHandleExceptionFilterAttribute]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = exception.Path;
            ViewBag.message = exception.Error.Message;

            return View();
        }

        public IActionResult Hata1()
        {
            return View();
        }

        public IActionResult Hata2()
        {
            return View();
        }
    }
}