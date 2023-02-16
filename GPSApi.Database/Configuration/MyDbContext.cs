using GPSApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPSApi.Database.Configuration
{
    internal class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PointOfInterest>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PointOfInterest>()
                .Property(p => p.PointX)
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<PointOfInterest>()
                .Property(p => p.PointY)
                .HasDefaultValue(0)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
