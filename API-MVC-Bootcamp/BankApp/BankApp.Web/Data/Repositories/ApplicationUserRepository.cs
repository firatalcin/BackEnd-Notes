using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;

namespace BankApp.Web.Data.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly AppDbContext _context;

        public ApplicationUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }

        public ApplicationUser Get(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(u => u.Id == id);
        }
    }
}
