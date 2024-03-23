using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IGenericRepository<ApplicationUser> _applicationUserRepository;

        public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> applicationUserRepository)
        {
            _accountRepository = accountRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.GetById(id);
            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                ApplicationUserId = accountCreateModel.ApplicationUserId
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int id) 
        {
            var query = _accountRepository.GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserId == id).ToList();

            var user = _applicationUserRepository.GetById(id);
            var list = new List<AccounListModel>();
            ViewBag.FullName = user.Name + " " + user.Surname;

            foreach (var account in accounts) 
            {
                list.Add(new AccounListModel
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserId = account.ApplicationUserId,
                    Id = account.Id
                });
            }

            

            return View(list);
        }
    }
}
