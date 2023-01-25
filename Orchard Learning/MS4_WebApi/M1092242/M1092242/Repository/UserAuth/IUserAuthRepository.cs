using M1092242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Repository.UserAuth
{
    public interface IUserAuthRepository
    {
        Task<PersonModel> Login(LoginRequestModel credentials);
        Task<PersonModel> Register(PersonModel person);
        public Task CheckEmailExist(string email);
    }
}
