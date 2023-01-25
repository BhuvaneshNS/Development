using LibraryManagement.CustomException;
using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryManagement.DataAccessLayer
{
    public class AdminOperationsDAL
    {
        public static void AdminAddLibraryDAL(Library library)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    SqlCommand command = new SqlCommand("spAddLibrary", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", library.Name);
                    command.Parameters.AddWithValue("@city", library.City);
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new CrudException("Someting went wrong!!! Failed to add library");
                    }
                }

            }
            catch (CrudException ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        public static void AdminAddBookDAL(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    SqlCommand command = new SqlCommand("spAddBook", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", book.Name);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@publisher", book.Publisher);
                    command.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new CrudException("Someting went wrong!!! Failed to add book");
                    }
                }

            }
            catch (CrudException ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        public static void AdminUpdateLibraryDAL(Library library)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    SqlCommand command = new SqlCommand("spUpdateLibrary", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", library.Name);
                    command.Parameters.AddWithValue("@city", library.City);
                    command.Parameters.AddWithValue("@libraryId", library.LibraryId);
                    command.Parameters.AddWithValue("@active", library.Active);
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new CrudException("Someting went wrong!!! Failed to update library");
                    }
                }

            }
            catch (CrudException ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        public static void AdminUpdateBookDAL(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    SqlCommand command = new SqlCommand("spUpdateBook", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", book.Name);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@publisher", book.Publisher);
                    command.Parameters.AddWithValue("@active", book.Active);
                    command.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
                    command.Parameters.AddWithValue("@bookId", book.BookId);
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new CrudException("Someting went wrong!!! Failed to update Book");
                    }
                }

            }
            catch (CrudException ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }

        public static void AdminDeleteALibraryDAL(int libraryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    SqlCommand command = new SqlCommand("spDeleteLibrary", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@libraryId", libraryId);
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new CrudException("Someting went wrong!!! Failed to delete library");
                    }
                }

            }
            catch (CrudException ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        public static void AdminDeleteABookDAL(int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    SqlCommand command = new SqlCommand("spDeleteBook", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@bookId", bookId);
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new CrudException("Someting went wrong!!! Failed to delete book");
                    }
                }

            }
            catch (CrudException ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }

        public static List<Library> GetAllLibrariesDAL()
        {
            List<Library> libraries = new List<Library>();
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllLibraries", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libraries.Add(new Library()
                            {
                                LibraryId = Convert.ToInt32(reader["LibraryId"]),
                                Active = Convert.ToInt32(reader["Active"]),
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString()
                            });
                        }
                    }

                }
                return libraries;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return libraries;
        }
        public static List<Book> GetAllBooksDAL()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book()
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                Active = Convert.ToInt32(reader["Active"]),
                                Name = reader["Name"].ToString(),
                                Author = reader["Author"].ToString(),
                                Publisher = reader["Publisher"].ToString(),
                                PublishedYear = Convert.ToInt32(reader["PublishedYear"])
                            });
                        }
                    }

                }
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return books;
        }

        public static Library GetALibraryDAL(int libraryId)
        {
            Library library = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetALibrary", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@libraryId", libraryId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            library = new Library()
                            {
                                LibraryId = Convert.ToInt32(reader["LibraryId"]),
                                Active = Convert.ToInt32(reader["Active"]),
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString()
                            };
                        }
                    }

                }
                return library;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return library;
        }
        public static Book GetABookDAL(int bookId)
        {
            Book book = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Config.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetABook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book = new Book()
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                Active = Convert.ToInt32(reader["Active"]),
                                Name = reader["Name"].ToString(),
                                Author = reader["Author"].ToString(),
                                Publisher = reader["Publisher"].ToString(),
                                PublishedYear = Convert.ToInt32(reader["PublishedYear"])
                            };
                        }
                    }

                }
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return book;
        }
    }
}
