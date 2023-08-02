using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
