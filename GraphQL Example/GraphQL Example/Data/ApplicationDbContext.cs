using GraphQL_Example.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cake> Cakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("graphql");

            modelBuilder.Entity<Cake>().HasData(SeedCakes);
        }

        private static readonly Cake[] SeedCakes =
        {
            new () { Id = 1, Name = "Cake #1", Price = 100m, Description = "Description #111" },
            new () { Id = 2, Name = "Cake #2", Price = 200m, Description = "Description #222" },
            new () { Id = 3, Name = "Cake #3", Price = 300m, Description = "Description #333" },
            new () { Id = 4, Name = "Cake #4", Price = 400m, Description = "Description #444" },
            new () { Id = 5, Name = "Cake #5", Price = 500m, Description = "Description #555" },
        };

    }
}
