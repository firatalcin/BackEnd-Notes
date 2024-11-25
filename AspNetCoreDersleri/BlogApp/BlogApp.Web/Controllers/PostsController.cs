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
    public async Task<IActionResult> Index(string tag)
    {
        var posts = _postRepository.Posts.Where(i => i.IsActive);

        if(!string.IsNullOrEmpty(tag))
        {
            posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
        }

        return View( new PostsViewModel { Posts = await posts.ToListAsync() });
    }

    public async Task<IActionResult> Details(string url)
    {
        return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.Url == url));
    }
}