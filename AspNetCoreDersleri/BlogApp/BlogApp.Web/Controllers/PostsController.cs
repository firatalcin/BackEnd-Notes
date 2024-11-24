using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Data.Concrete.EfCore;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Controllers;

public class PostsController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;

    public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
    }

    // GET
    public IActionResult Index()
    {
        var list = _postRepository.Posts.ToList();
        return View(new PostsViewModel
        {
            Posts = list
        });
    }

    public async Task<IActionResult> Details(string url)
    {
        return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.Url == url));
    }
}