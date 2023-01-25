using M1092242.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<PersonModel> People { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<FastFoodShopModel> FoodShops { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RoleModel>().HasData(new RoleModel() { RoleId = 1, RoleName = "Admin" }, new RoleModel() { RoleId = 2, RoleName = "User" });
        }
    }
}
