using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Data.Concrete.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _repository;

        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Posts.ToList());
        }
    }
}
