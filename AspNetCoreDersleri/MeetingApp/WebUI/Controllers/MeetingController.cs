using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class MeetingController : Controller
    {
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo userInfo)
        {
            Repository.CreateUser(userInfo);
            ViewBag.UserCount = Repository.Users().Where(x => x.WillAttend == true).Count();
            return View("Thanks", userInfo);
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
