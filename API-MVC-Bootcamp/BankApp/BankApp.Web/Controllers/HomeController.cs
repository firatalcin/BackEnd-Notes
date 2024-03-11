using BankApp.Web.Data.Context;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ApplicationUserRepository _applicationUserRepository;

        public HomeController(AppDbContext context)
        {
            _context = context;
            _applicationUserRepository = new ApplicationUserRepository(_context);
        }

        public IActionResult Index()
        {
            return View(_applicationUserRepository.GetAll());
        }
    }
}
