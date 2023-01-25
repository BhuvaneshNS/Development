using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
        public int Active { get; set; }

        public static void Display(List<Book> books)
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\n***** List of Books *****");
                foreach (Book book in books)
                {
                    Display(book);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nNo books found!!!\n");
            }
        }

        public static void Display(Book book)
        {
            if (book != null && book.BookId != 0)
            {
                Console.WriteLine("Id= " + book.BookId + " \tName= " + book.Name + "\tAuthor= " + book.Author + "\tPublisher= " + book.Publisher + "\tPublished year= " + book.PublishedYear + "\tStatus= " + (book.Active == 0 ? "Inactive" : "Active"));
            }
            else
            {
                Console.WriteLine("\nNo books found!!!\n");
            }
        }
    }
}
