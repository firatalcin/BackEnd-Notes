using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Login()
    {
        return View();
    }
}