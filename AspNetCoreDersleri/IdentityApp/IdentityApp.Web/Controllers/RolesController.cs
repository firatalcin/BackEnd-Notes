using IdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers;

public class RolesController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public RolesController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        return View(_roleManager.Roles.ToList());
    }

    // GET
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async  Task<IActionResult> Create(AppRole role)
    {
        if (ModelState.IsValid)
        {
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);   
            }
        }
        return View(role);
    }
}