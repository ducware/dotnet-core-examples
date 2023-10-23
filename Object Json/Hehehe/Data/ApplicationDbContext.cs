using Hehehe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hehehe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>(ConfigurePlan);
            modelBuilder.Entity<Expiration>().HasNoKey();
        }

        private void ConfigurePlan(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.ExpirationJson);
        }

    }
}
