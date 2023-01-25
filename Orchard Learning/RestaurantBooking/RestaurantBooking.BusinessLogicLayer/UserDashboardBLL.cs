using RestaurantBooking.DataAccessLayer;
using RestaurantBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.BusinessLogicLayer
{
    public class UserDashboardBLL
    {
        public static List<Restaurant> GetAllRestaurantsBLL()
        {
            try
            {
                return UserDashboardDAL.GetAllRestaurantsDAL();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int BookAMealBLL(Booking booking)
        {
            try
            {
                return UserDashboardDAL.BookAMealDAL(booking);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<BookingDetail> GetAllBookingsBLL(int userId)
        {
            try
            {
                return UserDashboardDAL.GetAllBookingsDAL(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
