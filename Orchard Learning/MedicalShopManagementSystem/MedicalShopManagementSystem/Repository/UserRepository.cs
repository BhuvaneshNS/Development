using MedicalShopManagementSystem.DataAccess;
using MedicalShopManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<UserModel> AddUser(UserModel newUser)
        {
            try
            {
                var addedUser = await appDbContext.Users.AddAsync(newUser);
                await appDbContext.SaveChangesAsync();
                return addedUser.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserModel> CheckEmailExist(string email)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task DeleteUser(int id)
        {
            var result = await appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            return await appDbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserRoleModel> GetUserRole(int roleId)
        {
            return await appDbContext.UserRole.FirstOrDefaultAsync(ur => ur.Id == roleId);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Login(LoginRequestModel user)
        {
            return await appDbContext.Users.Include(u => u.UserRole).FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        }

        public async Task<UserModel> UpdateUser(UserModel updatedUser)
        {
            var existingUser = await appDbContext.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Gender = updatedUser.Gender;
                existingUser.DOB = updatedUser.DOB;
                existingUser.Email = updatedUser.Name;
                existingUser.Password = updatedUser.Password;
                existingUser.RoleId = updatedUser.RoleId;
                existingUser.MedicalShopId = updatedUser.MedicalShopId;
            }
            await appDbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
