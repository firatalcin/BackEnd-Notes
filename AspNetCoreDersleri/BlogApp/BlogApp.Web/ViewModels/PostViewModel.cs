using BlogApp.Web.Entities;

namespace BlogApp.Web.ViewModels
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }
}
