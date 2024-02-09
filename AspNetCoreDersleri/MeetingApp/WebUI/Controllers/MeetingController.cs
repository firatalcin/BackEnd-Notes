using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(string Name, string Phone, string Email, bool WillAttend)
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
