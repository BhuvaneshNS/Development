using RestaurantBooking.DataAccessLayer;
using RestaurantBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.BusinessLogicLayer
{
    public class UserAuthBLL
    {
        public static int UseRegistrationBLL(User user)
        {
            try
            {
                return UserAuthDAL.UserRegistrationDAL(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static User LoginBLL(string mailId, string password)
        {
            try
            {
                return UserAuthDAL.LoginDAL(mailId, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
