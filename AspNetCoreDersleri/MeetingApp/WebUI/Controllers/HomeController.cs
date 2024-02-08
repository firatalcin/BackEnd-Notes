using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            var selamlama = saat > 12 ? "İyi Günler" : "Günaydın";

            ViewBag.selamlama = selamlama;  

            //ViewData["Selamla"] = selamlama;

            return View();
        }
    }
}
