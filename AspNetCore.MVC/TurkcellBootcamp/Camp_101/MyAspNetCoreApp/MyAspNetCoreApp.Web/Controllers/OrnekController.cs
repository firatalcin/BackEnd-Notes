using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product2>()
            {
                new(){Id = 1, Name = "Kalem"},
                new(){Id = 2, Name = "Defter"},
                new(){Id = 3, Name = "Silgi"},
            };


            // Veri taşıma yolları

            ViewBag.name = "aspnetcore";

            ViewData["age"] = 24;

            TempData["no"] = 12345;

            TempData["surname"] = "alcin";

            return View(products);
        }

        public IActionResult Index2()
        {
            var surname = TempData["surname"];

            return View();
        }

        //Parametreli action tanımlama

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResult2", new { id });
        }

        public IActionResult JsonResult2(int id)
        {
            return Json(new { id = id, name = "firat" });
        }

        // Yönlendirme Metodu

        public IActionResult Index3()
        {
            return RedirectToAction("Index", "Ornek");
        }

        // Farklı dönüş tipleri

        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        public IActionResult JsonResult()
        {
            return Json(new { id = 1, name = "firat" });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }

        
    }
}
