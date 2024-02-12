using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebUI.FakeDb;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string searchString, string category)
        {
            var products = Repository.GetProductList();
            ViewBag.SearchString = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = Repository.GetProductList().Where(x => x.Name.ToLower().Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(category) && category != "0")
            {
                products = products.Where(x => x.CategoryId == int.Parse(category)).ToList();
            }

            //ViewBag.Categories = new SelectList(Repository.GetCategoryList(), "Id", "Name", category);

            var model = new ProductViewModel();
            model.Products = products;
            model.Categories = Repository.GetCategoryList();
            model.SelectedCategory = category;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            return View();
        }
    }
}
