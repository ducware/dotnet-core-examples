
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }
        
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(buider =>
                buider.OwnsOne(a => a.Tags, tagsBuilder => tagsBuilder.ToString()));
        }
    }
}
