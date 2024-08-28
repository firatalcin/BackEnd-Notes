using BlogApp.Web.Entities;

namespace BlogApp.Web.ViewModels
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; } = new();
    }
}
