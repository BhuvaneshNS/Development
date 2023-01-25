using LibraryManagement.BusinessLogicLayer;
using LibraryManagement.CustomException;
using LibraryManagement.Entities;
using System;
using System.Collections.Generic;

namespace LibraryManagement.PresentationLayer
{
    public class AdminOperations
    {
        public static void AdminMenu()
        {
            try
            {
                bool exit = false;
                do
                {
                Start:
                    Console.WriteLine("1. Add a library");
                    Console.WriteLine("2. List all libraries");
                    Console.WriteLine("3. Update library details");
                    Console.WriteLine("4. Delete a library");
                    Console.WriteLine("5. Add a book");
                    Console.WriteLine("6. List all books");
                    Console.WriteLine("7. Update book details");
                    Console.WriteLine("8. Delete a book");
                    Console.WriteLine("9. Exit");

                    Console.WriteLine("Enter your choice");
                    if (!Int32.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Enter valid choice[Digits only]");
                        goto Start;
                    }
                    switch (choice)
                    {
                        case 1:
                            AdminAddLibrary();
                            break;
                        case 2:
                            AdminGetAllLibraries();
                            break;
                        case 3:
                            AdminUpdateALibrary();
                            break;
                        case 4:
                            AdminDeleteALibrary();
                            break;
                        case 5:
                            AdminAddBook();
                            break;
                        case 6:
                            AdminGetAllBooks();
                            break;
                        case 7:
                            AdminUpdateABook();
                            break;
                        case 8:
                            AdminDeleteABook();
                            break;
                        case 9:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                } while (!exit);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }

        private static void AdminAddBook()
        {
        Start:
            try
            {
                Console.Write("Enter book name: ");
                string name = Console.ReadLine();
                Console.Write("Enter author name : ");
                string authorName = Console.ReadLine();
                Console.Write("Enter publisher name : ");
                string publisherName = Console.ReadLine();
            GetYear:
                Console.Write("Enter published year : ");
                bool isInputValid = Int32.TryParse(Console.ReadLine(), out int publishedYear);
                if (!isInputValid)
                {
                    Console.WriteLine("Enter valid year");
                    goto GetYear;
                }

                Book book = new Book()
                {
                    Name = name,
                    Author = authorName,
                    Publisher = publisherName,
                    PublishedYear = publishedYear

                };
                AdminOperationsBLL.AdminAddBookBLL(book);
                Console.WriteLine("\nBook added successfully\n");
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
                goto Start;
            }
            catch (CrudException ce)
            {
                Console.WriteLine(ce.Message);
                //goto Start;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
                //goto Start;
            }

        }

        private static void AdminDeleteALibrary()
        {
            try
            {
            GetId:
                Console.Write("Enter library id to delete : ");
                bool isValidinput = Int32.TryParse(Console.ReadLine(), out int libraryId);
                if (!isValidinput)
                {
                    Console.WriteLine("Please enter valid input");
                    goto GetId;
                }
                if (GetALibrary(libraryId) != null)
                {
                    AdminOperationsBLL.AdminDeleteALibraryBLL(libraryId);
                    Console.WriteLine("\nLibrary deleted successfully\n");
                }
            }
            catch (CrudException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        private static void AdminDeleteABook()
        {
            try
            {
            GetId:
                Console.Write("Enter book id to delete : ");
                bool isValidinput = Int32.TryParse(Console.ReadLine(), out int bookId);
                if (!isValidinput)
                {
                    Console.WriteLine("Please enter valid input");
                    goto GetId;
                }
                if (GetALibrary(bookId) != null)
                {
                    AdminOperationsBLL.AdminDeleteABookBLL(bookId);
                    Console.WriteLine("\nBook deleted successfully\n");
                }
            }
            catch (CrudException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }

        private static void AdminUpdateALibrary()
        {
        Start:
            try
            {
            GetId:
                Console.Write("Enter library id : ");
                bool isValidInput = Int32.TryParse(Console.ReadLine(), out int libraryId);
                if (!isValidInput)
                {
                    Console.WriteLine("Enter valid input");
                    goto GetId;
                }
                if (GetALibrary(libraryId) != null)
                {
                    Console.Write("Enter updated name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter updated city: ");
                    string city = Console.ReadLine();

                Status:
                    Console.WriteLine("Change status 1. Inactive  2. Active");
                    isValidInput = Int32.TryParse(Console.ReadLine(), out int status);
                    if (!isValidInput || (status < 1 && status > 2))
                    {
                        Console.WriteLine("Enter valid option");
                        goto Status;
                    }
                    Library library = new Library()
                    {
                        Name = name,
                        City = city,
                        LibraryId = libraryId,
                        Active = status - 1
                    };
                    AdminOperationsBLL.AdminUpdateLibraryBLL(library);
                    Console.WriteLine("\nLibrary updated successfully\n");
                }

            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
                goto Start;
            }
            catch (CrudException ce)
            {
                Console.WriteLine(ce.Message);
                //goto Start;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }

        }
        private static void AdminUpdateABook()
        {
        Start:
            try
            {
            GetId:
                Console.Write("Enter Book id : ");
                bool isValidInput = Int32.TryParse(Console.ReadLine(), out int bookId);
                if (!isValidInput)
                {
                    Console.WriteLine("Enter valid input");
                    goto GetId;
                }
                if (GetABook(bookId) != null)
                {
                    Console.Write("Enter book name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter author name : ");
                    string authorName = Console.ReadLine();
                    Console.Write("Enter publisher name : ");
                    string publisherName = Console.ReadLine();
                GetYear:
                    Console.Write("Enter published year : ");
                    bool isInputValid = Int32.TryParse(Console.ReadLine(), out int publishedYear);
                    if (!isInputValid)
                    {
                        Console.WriteLine("Enter valid year");
                        goto GetYear;
                    }

                Status:
                    Console.WriteLine("Change status 1. Inactive  2. Active");
                    isValidInput = Int32.TryParse(Console.ReadLine(), out int status);
                    if (!isValidInput || (status < 1 && status > 2))
                    {
                        Console.WriteLine("Enter valid option");
                        goto Status;
                    }

                    Book book = new Book()
                    {
                        BookId = bookId,
                        Name = name,
                        Author = authorName,
                        Publisher = publisherName,
                        PublishedYear = publishedYear,
                        Active = status - 1
                    };

                    AdminOperationsBLL.AdminUpdateBookBLL(book);
                    Console.WriteLine("\nBook updated successfully\n");
                }

            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
                goto Start;
            }
            catch (CrudException ce)
            {
                Console.WriteLine(ce.Message);
                //goto Start;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }

        }

        public static void AdminGetAllLibraries()
        {
            try
            {
                List<Library> libraries = AdminOperationsBLL.GetAllLibrariesBLL();
                Library.Display(libraries);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        public static void AdminGetAllBooks()
        {
            try
            {
                List<Book> books = AdminOperationsBLL.GetAllBooksBLL();
                Book.Display(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }

        public static Library GetALibrary(int libraryId)
        {
            Library library = null;
            try
            {
                library = AdminOperationsBLL.GetALibraryBLL(libraryId);
                Library.Display(library);
                return library;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return library;
        }
        public static Book GetABook(int bookId)
        {
            Book book = null;
            try
            {
                book = AdminOperationsBLL.GetABookBLL(bookId);
                Book.Display(book);
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
            return book;
        }
        public static void AdminAddLibrary()
        {
        Start:
            try
            {
                Console.Write("Enter library name: ");
                string name = Console.ReadLine();
                Console.Write("Enter library city: ");
                string city = Console.ReadLine();

                Library library = new Library()
                {
                    Name = name,
                    City = city,

                };
                AdminOperationsBLL.AdminAddLibraryBLL(library);
                Console.WriteLine("\nLibrary added successfully\n");
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
                goto Start;
            }
            catch (CrudException ce)
            {
                Console.WriteLine(ce.Message);
                //goto Start;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
                //goto Start;
            }
        }
    }
}
