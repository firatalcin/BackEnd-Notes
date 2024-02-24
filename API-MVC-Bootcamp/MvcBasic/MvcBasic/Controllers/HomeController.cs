using Microsoft.AspNetCore.Mvc;
using MvcBasic.Models;
using System.Diagnostics;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Fýrat";
            ViewData["Name"] = "Fýrat";
            TempData["Name"] = "Fýrat";

            var values = int.Parse(RouteData.Values["id"].ToString());

            Customer customer = new Customer() { Age = 25, FirstName = "Fýrat", LastName = "Alçýn"}; 

            //return View(customer);
            return RedirectToAction("Index2");
        }

        [Route("Fýrat")]
        public IActionResult Index2()
        {
            return View();
        }
    }
}
