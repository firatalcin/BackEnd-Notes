using BankApp.Web.Data.Context;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _context.ApplicationUsers.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).SingleOrDefault(x => x.Id == id);

            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _context.Accounts.Add(new Data.Entities.Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                ApplicationUserId = accountCreateModel.ApplicationUserId
            });

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
