using Microsoft.EntityFrameworkCore;
using Mobile_Appliction.Model;

namespace Mobile_Appliction.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }
        public DbSet<Category> Category { get; set; }
    }
}
