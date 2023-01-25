using MedicalShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Repository
{
    public interface IUserRepository
    {
        public Task<UserModel> AddUser(UserModel newUser);
        public Task<UserModel> UpdateUser(UserModel updatedUser);
        public Task<UserModel> CheckEmailExist(string email);
        public Task<UserModel> Login(LoginRequestModel user);
        public Task<UserRoleModel> GetUserRole(int roleId);
        public Task<List<UserModel>> GetUsers();
        public Task<UserModel> GetUser(int id);
        public Task DeleteUser(int id);
    }
}
