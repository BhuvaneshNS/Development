using LibraryManagement.BusinessLogicLayer;
using LibraryManagement.Entities;
using System;

namespace LibraryManagement.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool exitApp = false;
                do
                {
                    Console.WriteLine("WELCOME TO LIBRARY MANAGEMENT SYSTEM\n");
                AppStart:
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("\nProceed with your choice");
                    int choice = 0;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\nPlease enter valid digits only\n");
                        goto AppStart;
                    }
                    switch (choice)
                    {
                        case 1:
                            UserAuthentication.Login();
                            break;
                        case 2:
                            UserAuthentication.Register();
                            break;
                        case 3:
                            exitApp = true;
                            break;
                        default:
                            break;
                    }
                } while (!exitApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
