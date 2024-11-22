using BlogApp.Web.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers;

public class PostsController : Controller
{
    private readonly AppDbContext _context;

    public PostsController(AppDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        return View(_context.Posts.ToList());
    }
}