using books.Models;
using Microsoft.EntityFrameworkCore;

namespace books.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books_core { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(u => u.Title).IsUnique();
        }
    }
}
