using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Concrete.EFCore
{
    public class EfPostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Posts => _context.Posts;

        public void Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}
