using Microsoft.EntityFrameworkCore;
using WebUI.Data;

namespace WebUI.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
