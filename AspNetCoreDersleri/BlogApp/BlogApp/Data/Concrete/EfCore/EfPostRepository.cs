using BlogApp.Data.Context;
using BlogApp.Data.Interfaces;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges(); 
        }

        public IQueryable<Post> PostList()
        {
            return _context.Posts;
        }
    }
}
