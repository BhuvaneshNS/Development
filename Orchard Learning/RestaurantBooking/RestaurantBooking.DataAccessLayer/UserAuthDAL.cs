using RestaurantBooking.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBooking.CustomException;

namespace RestaurantBooking.DataAccessLayer
{
    public class UserAuthDAL
    {
        public static int UserRegistrationDAL(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spCheckMailExist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mailId", user.MailId);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            throw new DuplicateMailIdException("Mail id alredy exist");
                        }
                    }

                    cmd.Parameters.AddWithValue("@fName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lName", user.LastName);
                    cmd.Parameters.AddWithValue("@gender", user.Gender);
                    cmd.Parameters.AddWithValue("@dob", user.DOB);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    cmd.CommandText = "spUserRegistration";
                    return cmd.ExecuteNonQuery();
                }

            }
            catch (DuplicateMailIdException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static User LoginDAL(string mailId, string password)
        {
            try
            {
                User loggedUser = new User();
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mailId", mailId);
                    cmd.Parameters.AddWithValue("@password", password);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            loggedUser.UserId = Convert.ToInt32(rdr["UserId"]);
                            loggedUser.FirstName = rdr["FirstName"].ToString();
                            loggedUser.LastName = rdr["LastName"].ToString();
                        }
                    }
                }
                return loggedUser;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}

