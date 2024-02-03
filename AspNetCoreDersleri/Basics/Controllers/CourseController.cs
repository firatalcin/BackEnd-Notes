using Microsoft.AspNetCore.Mvc;
using Basics.Models;

namespace Basics.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            Course kurs = new Course();
            kurs.Id = 1;
            kurs.Title = "Aspnet Core kursu";
            return View(kurs);
        }

        public IActionResult List(){

            List<Course> courses = new List<Course>(){
                new Course(){Id = 1, Title = ".Net Core"},
                new Course(){Id = 2, Title = "Spring Boot"}
            };
            return View(courses);
        }

    }
}