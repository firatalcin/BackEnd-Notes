using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        void Create(Post post);
    }
}
