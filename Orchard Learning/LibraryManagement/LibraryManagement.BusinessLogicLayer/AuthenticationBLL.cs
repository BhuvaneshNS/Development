using LibraryManagement.CustomException;
using LibraryManagement.DataAccessLayer;
using LibraryManagement.Entities;
using System;

namespace LibraryManagement.BusinessLogicLayer
{
    public class AuthenticationBLL
    {
        //Method accepts mailid and password to validate authentic user
        public User AuthenticateLogin(string mailId, string password)
        {
            User user = new User();
            try
            {
                AuthenticationDAL login = new AuthenticationDAL();
                return login.AuthenticateLogin(mailId, password);
            }
            catch (AuthenticationFailedException afe)
            {
                throw new AuthenticationFailedException(afe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            return user;
        }
        public int CreateNewUser(User newUser)
        {
            try
            {
                if (string.IsNullOrEmpty(newUser.Name) || string.IsNullOrEmpty(newUser.City) || string.IsNullOrEmpty(newUser.MailId) || string.IsNullOrEmpty(newUser.Password))
                {
                    return 3;
                }
                AuthenticationDAL registration = new AuthenticationDAL();
                return registration.CreateNewUser(newUser);
            }
            catch (RegistrationFailedException rfe)
            {
                throw new RegistrationFailedException(rfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex.Message);
            }
            return 0;
        }
    }
}
