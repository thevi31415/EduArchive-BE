using EduArchive_BE.Model;
using Microsoft.EntityFrameworkCore;

namespace EduArchive_BE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
        public DbSet<User> users { get; set; }
        public DbSet<Document> documents { get; set; }
    }
}
