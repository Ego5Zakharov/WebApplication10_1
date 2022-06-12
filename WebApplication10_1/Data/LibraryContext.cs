using Microsoft.EntityFrameworkCore;
using WebApplication10_1.Models;

namespace WebApplication10_1.Data
{
    public class LibraryContext : DbContext
    { 
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
