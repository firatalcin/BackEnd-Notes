using BlogApp.Entity;

namespace BlogApp.Data.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<Post> PostList();
        void CreatePost(Post post);
    }
}
