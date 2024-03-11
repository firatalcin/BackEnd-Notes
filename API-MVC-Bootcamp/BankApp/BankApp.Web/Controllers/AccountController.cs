using BankApp.Web.Data.Context;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ApplicationUserRepository _applicationUserRepository;

        public AccountController(AppDbContext context)
        {
            _context = context;
            _applicationUserRepository = new ApplicationUserRepository(_context);
        }

        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.Get(id);
            return View(userInfo);
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
