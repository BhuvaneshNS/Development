using MedicalShopManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<MedicalShopModel> MedicalShops { get; set; }
        public DbSet<MedicineModel> Medicines { get; set; }
        public DbSet<UserRoleModel> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRoleModel>().HasData(new UserRoleModel() { Id = 1, RoleType = "Admin" }, new UserRoleModel() { Id = 2, RoleType = "ShopKeeper" });
        }
    }
}
