using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Domain.Enum;
using OnlineLibrary.Domain.Helpers;

namespace OnlineLibrary.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Users> Users { get; set; }

        
    }
}
