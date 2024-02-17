using Microsoft.AspNetCore.Mvc;
using WebUI.Context;
using WebUI.Data;

namespace WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");           
        }
    }
}
