using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;

public class PostsController : Controller
{
    private readonly IPostRepository _postRepository;

    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    // GET
    public IActionResult Index()
    {
        var list = _postRepository.Posts.ToList();
        return View(list);
    }
}