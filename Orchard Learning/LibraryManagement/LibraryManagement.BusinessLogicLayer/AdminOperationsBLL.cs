using LibraryManagement.CustomException;
using LibraryManagement.DataAccessLayer;
using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.BusinessLogicLayer
{
    public class AdminOperationsBLL
    {
        public static void AdminAddLibraryBLL(Library library)
        {
            try
            {
                if (string.IsNullOrEmpty(library.Name) || string.IsNullOrEmpty(library.City))
                    throw new ValidationException("Null values are not allowed");
                AdminOperationsDAL.AdminAddLibraryDAL(library);
            }
            catch (ValidationException ve)
            {
                throw ve;
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
        public static void AdminAddBookBLL(Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Publisher))
                    throw new ValidationException("Null values are not allowed");
                AdminOperationsDAL.AdminAddBookDAL(book);
            }
            catch (ValidationException ve)
            {
                throw ve;
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
        public static void AdminUpdateLibraryBLL(Library library)
        {
            try
            {
                if (string.IsNullOrEmpty(library.Name) || string.IsNullOrEmpty(library.City))
                    throw new ValidationException("Null values are not allowed");
                AdminOperationsDAL.AdminUpdateLibraryDAL(library);
            }
            catch (ValidationException ve)
            {
                throw ve;
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
        public static void AdminUpdateBookBLL(Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Publisher))
                    throw new ValidationException("Null values are not allowed");
                AdminOperationsDAL.AdminUpdateBookDAL(book);
            }
            catch (ValidationException ve)
            {
                throw ve;
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

        public static List<Library> GetAllLibrariesBLL()
        {
            List<Library> libraries = new List<Library>();
            try
            {
                return AdminOperationsDAL.GetAllLibrariesDAL();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return libraries;
        }
        public static List<Book> GetAllBooksBLL()
        {
            List<Book> books = new List<Book>();
            try
            {
                return AdminOperationsDAL.GetAllBooksDAL();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return books;
        }

        public static Library GetALibraryBLL(int libraryId)
        {
            return AdminOperationsDAL.GetALibraryDAL(libraryId);
        }
        public static Book GetABookBLL(int bookId)
        {
            return AdminOperationsDAL.GetABookDAL(bookId);
        }

        public static void AdminDeleteALibraryBLL(int libraryId)
        {
            AdminOperationsDAL.AdminDeleteALibraryDAL(libraryId);
        }
        public static void AdminDeleteABookBLL(int bookId)
        {
            AdminOperationsDAL.AdminDeleteABookDAL(bookId);
        }
    }
}
