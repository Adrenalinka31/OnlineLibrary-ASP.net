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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(builder =>
            {
                builder.HasData(new Users
                {
                    Id = 1,
                    Name = "Kirill",
                    Password = HashPasswordHelper.HashPassword("123456"),
                    Role = Role.Admin
                });
                builder.ToTable("Users").HasKey(x => x.Id);
                builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
