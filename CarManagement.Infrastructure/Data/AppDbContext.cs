using CarManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace CarManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySql("Server=golar3.go.ro;Database=CarManagement;User=carManagement;Password=59885236;");
        }
    }
}