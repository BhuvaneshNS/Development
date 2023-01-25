using M1092242.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1092242.DataAccessLayer
{
    public class UserOperationDAL
    {
        public static int RegisterUserDAL(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spRegister", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@contactNumber", user.ContactNumber);
                    cmd.Parameters.AddWithValue("@address", user.Adress);
                    cmd.Parameters.AddWithValue("@bookingDate", user.AppointmentBookingDate);
                    cmd.Parameters.AddWithValue("@laptopMake", user.LaptopMake);
                    cmd.Parameters.AddWithValue("@laptopModel", user.LaptopModel);
                    cmd.Parameters.AddWithValue("@serviceCenterId", user.ServiceCenterId);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ServiceCenter> GetAllServiceCenters()
        {
            List<ServiceCenter> serviceCenters = new List<ServiceCenter>();
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCenters", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            serviceCenters.Add(
                                new ServiceCenter()
                                {
                                    ServiceCenterId = Convert.ToInt32(rdr["ServiceCenterId"]),
                                    ServiceCenterName = rdr["Location"].ToString(),
                                    Location = rdr["RestaurantName"].ToString(),

                                });
                        }
                    }

                }
                return serviceCenters;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
