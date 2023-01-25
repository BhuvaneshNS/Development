using E_Grocery_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Grocery_Store.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)

        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGender> Genders { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<GroceryCategory> GroceryCategories { get; set; }
        public DbSet<GroceryStatus> GroceryStatuses { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>().HasData(new UserRole() { Id = 1, Name = "Admin" }, new UserRole() { Id = 2, Name = "User" });


            modelBuilder.Entity<UserGender>().HasData(new UserGender() { Id = 1, Name = "Male" }, new UserGender() { Id = 2, Name = "Female" }, new UserGender() { Id = 3, Name = "Others" });


            modelBuilder.Entity<GroceryCategory>().HasData(new GroceryCategory() { Id = 1, Name = "Vegetables" }, new UserGender() { Id = 2, Name = "Fruits" }, new UserGender() { Id = 3, Name = "Grains" });


            modelBuilder.Entity<GroceryStatus>().HasData(new GroceryStatus() { Id = 1, Name = "Added" }, new GroceryStatus() { Id = 2, Name = "Approved" }, new UserGender() { Id = 3, Name = "Rejected" });


            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Name = "Bhuvanesh", RoleId = 1, Email = "bns@mail.com", Password = "123", GenderId = 1, DOB = new System.DateTime(1997, 05, 25) });

        }
    }
}
