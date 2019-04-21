using CarManagement.Core.Entities;
using CarManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        //public DbSet<CarDetail> CarDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder _builder)
        {
            _builder.UseMySql("Server=golar3.go.ro;Database=CarManagement;User=carManagement;Password=59885236;");
        }
    }
}
