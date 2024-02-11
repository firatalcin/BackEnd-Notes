using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.FakeDb;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.GetProductList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
