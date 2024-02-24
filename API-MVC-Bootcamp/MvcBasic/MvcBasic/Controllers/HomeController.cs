using Microsoft.AspNetCore.Mvc;
using MvcBasic.Models;
using System.Diagnostics;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "F�rat";
            ViewData["Name"] = "F�rat";
            TempData["Name"] = "F�rat";

            var values = int.Parse(RouteData.Values["id"].ToString());

            Customer customer = new Customer() { Age = 25, FirstName = "F�rat", LastName = "Al��n"}; 

            //return View(customer);
            return RedirectToAction("Index2");
        }

        [Route("F�rat")]
        public IActionResult Index2()
        {
            return View();
        }
    }
}
