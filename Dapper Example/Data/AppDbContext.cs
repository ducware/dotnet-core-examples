using DapperExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Fruit> Fruits { get; set; }
        
    }
}
