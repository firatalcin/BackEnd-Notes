using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public AccountController(AppDbContext context, IApplicationUserRepository applicationUserRepository, IUserMapper userMapper)
        {
            _context = context;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.GetById(id);
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
