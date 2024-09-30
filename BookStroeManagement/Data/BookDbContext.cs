using BookStroeManagement.Config;
using BookStroeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStroeManagement.Data
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions options)
           : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfig());
           

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TunifyDbContext).Assembly);

        }
        public DbSet<Book> Books { get; set; } = default!;
    }
}
