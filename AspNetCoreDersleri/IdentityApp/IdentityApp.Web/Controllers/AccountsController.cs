using IdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers
{
    public class AccountsController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new IdentityUser
                //{
                //    UserName = model.UserName,
                //    Email = model.Email,
                //    FullName = model.FullName
                //};

                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var url = Url.Action("ConfirmEmail", "Account", new { user.Id, token });

                    //// email
                    //await _emailSender.SendEmailAsync(user.Email, "Hesap Onayı", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5034{url}'>tıklayınız.</a>");

                    //TempData["message"] = "Email hesabınızdaki onay mailini tıklayınız.";
                    return RedirectToAction("Index", "Users");
                }

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

    }
}
