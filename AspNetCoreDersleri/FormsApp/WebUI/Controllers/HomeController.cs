using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.FakeDb;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string searchString)
        {
            var products = Repository.GetProductList();
            ViewBag.SearchString = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = Repository.GetProductList().Where(x => x.Name.ToLower().Contains(searchString)).ToList();
            }

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
