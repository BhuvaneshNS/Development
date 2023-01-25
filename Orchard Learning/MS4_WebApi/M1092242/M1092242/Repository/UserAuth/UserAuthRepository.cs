using M1092242.Common.CustomException;
using M1092242.DataAccess;
using M1092242.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Repository.UserAuth
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly AppDbContext appDbContext;

        public UserAuthRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<PersonModel> Login(LoginRequestModel credentials)
        {
            try
            {
                if (credentials == null)
                {
                    throw new RequestEmptyException("Request contains no data");
                }
                var person = await appDbContext.People.Include(p => p.Role).FirstOrDefaultAsync(p => p.EmailId == credentials.EmailId && p.Password == credentials.Password);
                if (person == null)
                {
                    throw new InvalidCredentialException("Invalid Credentials");
                }
                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonModel> Register(PersonModel person)
        {
            try
            {
                if (person == null)
                {
                    throw new RequestEmptyException("Request contains no data");
                }
                var registeredPerson = await appDbContext.People.AddAsync(person);
                await appDbContext.SaveChangesAsync();
                if (registeredPerson.Entity == null)
                {
                    throw new DbInsertException("Something went wrong. Failed to register");
                }
                return registeredPerson.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CheckEmailExist(string email)
        {
            try
            {
                var person = await appDbContext.People.FirstOrDefaultAsync(u => u.EmailId == email);
                if (person != null)
                {
                    throw new DuplicateMailIdException("Mail id is already in use");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
