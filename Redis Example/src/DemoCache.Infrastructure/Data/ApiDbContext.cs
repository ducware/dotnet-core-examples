using DemoCache.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCache.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Driver>(entity =>
        //    {
        //        // 1 - Many
        //        entity.HasOne(t => t.Team)
        //            .WithMany(t => t.Drivers)
        //            .OnDelete(DeleteBehavior.Restrict)
        //            .HasConstraintName("FK_Driver_Team");

        //        // 1 - 1
        //        entity.HasOne(dm => dm.DriverMedia)
        //            .WithOne(d => d.Driver)
        //            .HasForeignKey<DriverMedia>(x => x.DriverId);
        //    });
        //}
    }
}
