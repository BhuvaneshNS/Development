using LibraryManagement.CustomException;
using LibraryManagement.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement.DataAccessLayer
{
    public class AuthenticationDAL
    {
        //Method accepts mailid and password to validate authentic user
        public User AuthenticateLogin(string mailId, string password)
        {
            User loggedUser = new User();
            try
            {

                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAuthenticateLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mailId", mailId);
                    cmd.Parameters.AddWithValue("@password", password);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                loggedUser.UserId = Convert.ToInt32(reader["Userid"]);
                                loggedUser.Name = reader["Name"].ToString();
                                //user.Gender = reader["Gender"].ToString();
                                //user.City = reader["City"].ToString();
                                //user.Phone = Convert.ToInt64(reader["Phone"]);
                                //user.City = reader["City"].ToString();
                            }
                        }
                        else
                        {
                            throw new AuthenticationFailedException("Entered login credentials are incorrect...!!!");
                        }
                    }
                }
                return loggedUser;
            }
            catch (AuthenticationFailedException afe)
            {
                throw new AuthenticationFailedException(afe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            return loggedUser;
        }

        public int CreateNewUser(User newUser)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spCheckMailIdExist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mailId", newUser.MailId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return 2;
                        }
                    }
                    cmd.CommandText = "spCreateNewUser";
                    cmd.Parameters.AddWithValue("@name", newUser.Name);
                    cmd.Parameters.AddWithValue("@gender", newUser.Gender);
                    cmd.Parameters.AddWithValue("@city", newUser.City);
                    cmd.Parameters.AddWithValue("@phone", newUser.Phone);
                    cmd.Parameters.AddWithValue("@password", newUser.Password);
                    int status = cmd.ExecuteNonQuery();
                    if (status == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new RegistrationFailedException("Something went wrong, Registration failed!!!");
                    }
                }
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
