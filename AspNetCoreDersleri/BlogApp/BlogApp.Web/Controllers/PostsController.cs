using BlogApp.Web.Data.Abstract;
using BlogApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View(new PostViewModel
            {
                Posts = _postRepository.Posts.ToList(),
                Tags = _tagRepository.Tags.ToList()
            });
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _postRepository.Posts.FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
