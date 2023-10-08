using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;
        private ProjectContext _projectContext;
        private readonly IHelper _helper;

		public ProductController(ProjectContext projectContext, IHelper helper)
		{
			_productRepository = new ProductRepository();
			_projectContext = projectContext;
			_helper = helper;
		}

		[HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _projectContext.Products.Add(product);
            _projectContext.SaveChanges();
            TempData["Status"] = "Ürün başarıyla eklendi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _projectContext.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _projectContext.Update(product);
            _projectContext.SaveChanges();
            TempData["Status"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var text = "Asp.Net";

            var upperText = _helper.Upper(text);
            var products = _projectContext.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _projectContext.Products.Find(id);

            _projectContext.Remove(product);
            _projectContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
