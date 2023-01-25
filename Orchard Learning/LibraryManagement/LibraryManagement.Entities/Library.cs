using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Entities
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Active { get; set; }

        public static void Display(List<Library> libraries)
        {
            if (libraries.Count > 0)
            {
                Console.WriteLine("\n***** List of libraries *****");
                foreach (Library library in libraries)
                {
                    Display(library);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nNo libraries found!!!\n");
            }
        }

        public static void Display(Library library)
        {
            if (library != null && library.LibraryId != 0)
            {
                Console.WriteLine("Id= " + library.LibraryId + " \tName= " + library.Name + "\t\tCity= " + library.City + "\t\tStatus= " + (library.Active == 0 ? "Inactive" : "Active"));
            }
            else
            {
                Console.WriteLine("\nNo library found!!!\n");
            }
        }
    }
}
