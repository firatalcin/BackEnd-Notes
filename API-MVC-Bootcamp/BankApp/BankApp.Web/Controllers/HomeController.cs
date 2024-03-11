using BankApp.Web.Data.Context;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public HomeController(AppDbContext context, IUserMapper userMapper)
        {
            _context = context;
            _applicationUserRepository = new ApplicationUserRepository(_context);
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_applicationUserRepository.GetAll()));
        }
    }
}
