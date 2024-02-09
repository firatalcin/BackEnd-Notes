using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

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

            var meetingInfo = new MeetingAppInfo()
            {
                Id = 1,
                Location = "İstanbul, Abc Kongre Merkezi",
                Date = new DateTime(2025, 01, 20, 20, 0, 0),
                NumberOfPeople = 100
            };

            return View(meetingInfo);
        }
    }
}
