using Hangfire_RabbitMQ.Models;
using Microsoft.EntityFrameworkCore;

namespace Hangfire_RabbitMQ.Data
{
    public class ApplicationContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "Test",
                Password = "Test"

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
