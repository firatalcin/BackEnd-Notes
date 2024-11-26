﻿using System.Security.Claims;
using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Data.Concrete.EfCore;
using BlogApp.Web.Entities;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Controllers;

public class PostsController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;
    private readonly ICommentRepository _commentRepository;
    

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
        return View(await _postRepository
            .Posts
            .Include(x => x.User)
            .Include(x => x.Tags)
            .Include(x => x.Comments)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(p => p.Url == url));
    }
    
    [HttpPost]
    public JsonResult AddComment(int PostId, string Text)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.FindFirstValue(ClaimTypes.Name);
        var avatar = User.FindFirstValue(ClaimTypes.UserData);

        var entity = new Comment {
            PostId = PostId,
            Text = Text,
            PublishedOn = DateTime.Now,
            UserId = int.Parse(userId ?? "")
        };
        _commentRepository.CreateComment(entity);

        return Json(new { 
            username,
            Text,
            entity.PublishedOn,
            avatar
        });

    }
}