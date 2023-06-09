﻿using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entity;

namespace OnlineLibrary.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Book> Book { get; set; }

    }
}
