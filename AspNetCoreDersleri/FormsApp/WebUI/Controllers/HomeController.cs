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
            ViewBag.Categories = new SelectList(Repository.GetCategoryList(), "CategoryId", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product model, IFormFile imageFile)
        {
            var extension = "";
            if (imageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                extension = Path.GetExtension(imageFile.FileName); // abc.jpg

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Ge�erli bir resim se�iniz.");
                }
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFileName;
                    model.ProductId = Repository.GetProductList().Count + 1;
                    Repository.CreateProduct(model);
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Categories = new SelectList(Repository.GetProductList(), "CategoryId", "Name");
            return View(model);

        }
    }
}