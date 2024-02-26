using Microsoft.AspNetCore.Mvc;
using MvcBasic.Models;
using System.Diagnostics;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
        }

        [Route("Fýrat")]
        public IActionResult Index2()
        {
            return View();
        }
    }
}
