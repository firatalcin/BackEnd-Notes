using IdentityApp.Web.Models;
using IdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public UsersController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }


    // GET
    public IActionResult Index()
    {
        return View(_userManager.Users.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser()
            {
                UserName = model.Email.Split("@")[0],
                Email = model.Email,
                FullName = model.FullName,
            };
            
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            return View(new EditViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
            });
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, EditViewModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user.Email = model.Email;
                user.FullName = model.FullName;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                    
                    return RedirectToAction("Index");
                }
                else if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
        }
        return RedirectToAction("Index");
    }
}