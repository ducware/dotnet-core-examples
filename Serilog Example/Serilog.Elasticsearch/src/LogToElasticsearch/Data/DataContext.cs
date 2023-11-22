using LogToElasticsearch.Entities;
using LogToElasticsearch.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogToElasticsearch.Data
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
