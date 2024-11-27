using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult Login()
    {
        return View();
    }
}