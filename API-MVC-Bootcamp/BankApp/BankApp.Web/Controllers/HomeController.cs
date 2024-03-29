using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;

        public HomeController(IUserMapper userMapper, IUow uow)
        {
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
        }
    }
}
