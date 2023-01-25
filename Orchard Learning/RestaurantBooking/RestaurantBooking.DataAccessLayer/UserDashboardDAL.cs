using RestaurantBooking.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.DataAccessLayer
{
    public class UserDashboardDAL
    {
        public static List<Restaurant> GetAllRestaurantsDAL()
        {
            try
            {
                List<Restaurant> restaurants = new List<Restaurant>();

                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllRestourants", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            restaurants.Add(
                                new Restaurant()
                                {
                                    RestaurantId = Convert.ToInt32(rdr["RestaurantId"]),
                                    RestaurantName = rdr["RestaurantName"].ToString(),
                                    CityName = rdr["CityName"].ToString()

                                });
                        }
                    }

                }
                return restaurants;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<BookingDetail> GetAllBookingsDAL(int userId)
        {
            try
            {
                List<BookingDetail> bookingDetails = new List<BookingDetail>();
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllBookings", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            bookingDetails.Add(
                                new BookingDetail()
                                {
                                    BookingId = Convert.ToInt32(rdr["BookingId"]),
                                    NoOfPeople = Convert.ToInt32(rdr["NoOfPeople"]),
                                    RestaurantName = rdr["RestaurantName"].ToString(),
                                    MealType = rdr["MealType"].ToString(),
                                    BookiingDate = Convert.ToDateTime(rdr["BookingDate"])
                                });
                        }
                    }

                }
                return bookingDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int BookAMealDAL(Booking booking)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spBookRestaurant", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", booking.UserId);
                    cmd.Parameters.AddWithValue("@restaurantId", booking.RestaurantId);
                    cmd.Parameters.AddWithValue("@mealType", booking.MealType);
                    cmd.Parameters.AddWithValue("@noOfPeople", booking.NoOfPeople);
                    cmd.Parameters.AddWithValue("@bookingDate", booking.BookiingDate);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
