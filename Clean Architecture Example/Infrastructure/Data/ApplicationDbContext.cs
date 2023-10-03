using Domain.Common;
using Domain.Entities.Animal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("clean");

            modelBuilder.Entity<Animal>().HasData(SeedAnimals);
        }

        private static readonly Animal[] SeedAnimals =
        {
            new () { Id = 1, Name = "Animal #1", Description = "Description #1", Age = 1, IsBird = false, CreatedAt = DateTime.Now },
            new () { Id = 2, Name = "Animal #2", Description = "Description #2", Age = 2, IsBird = false, CreatedAt = DateTime.Now },
            new () { Id = 3, Name = "Animal #3", Description = "Description #3", Age = 3, IsBird = false, CreatedAt = DateTime.Now },
            new () { Id = 4, Name = "Animal #4", Description = "Description #4", Age = 4, IsBird = false, CreatedAt = DateTime.Now },
            new () { Id = 5, Name = "Animal #5", Description = "Description #5", Age = 5, IsBird = false, CreatedAt = DateTime.Now },
            
        };

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
