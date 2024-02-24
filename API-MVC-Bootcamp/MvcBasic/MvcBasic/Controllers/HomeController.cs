using Microsoft.AspNetCore.Mvc;
using MvcBasic.Models;
using System.Diagnostics;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Name = "F�rat";
            ViewData["Name"] = "F�rat";
            TempData["Name"] = "F�rat";

            Customer customer = new Customer() { Age = 25, FirstName = "F�rat", LastName = "Al��n"}; 

            return View(customer);
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
