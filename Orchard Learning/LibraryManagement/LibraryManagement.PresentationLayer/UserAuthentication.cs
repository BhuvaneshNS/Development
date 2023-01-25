using LibraryManagement.BusinessLogicLayer;
using LibraryManagement.CustomException;
using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.PresentationLayer
{
    public class UserAuthentication
    {
        public static void Login()
        {
            try
            {
                Console.WriteLine("**** Login ****");
                Console.Write("Enter registered mail id: ");
                string mailId = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                AuthenticationBLL login = new AuthenticationBLL();
                User loggedUser = login.AuthenticateLogin(mailId, password);
                //Valid user, Entered inside app sucessfully
                Console.WriteLine("\nWelcome {0}", loggedUser.Name);
                if (loggedUser.UserId == 1)
                {
                    AdminOperations.AdminMenu();
                }
                else
                {
                    UserOperations.UsersMenu();
                }

            }
            catch (AuthenticationFailedException afe)
            {
                bool exit = false;
                //Logic to handle invalid credential
                do
                {
                    Console.WriteLine(afe.Message);
                LoginFailedChoices:
                    Console.WriteLine("1. Try again");
                    Console.WriteLine("2. Don't have account, Register.");
                    Console.WriteLine("3. Exit");

                    Console.WriteLine("\nProceed with your choice");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("\nPlease enter valid digits only\n");
                        goto LoginFailedChoices;
                    }
                    switch (choice)
                    {
                        case 1:
                            Login();
                            exit = true;
                            break;
                        case 2:
                            Register();
                            exit = true;
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Please enter valid choice");
                            break;
                    }

                } while (!exit);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message);
            }
        }
        public static void Register()
        {
            try
            {
                Console.WriteLine("***** Registration *****");
                Console.Write("Enter name : ");
                string name = Console.ReadLine();
                string gender = null;
                while (true)
                {
                GenderChoices:
                    Console.Write("1.Male  2.Female  3.Other");
                    Console.WriteLine();
                    Console.Write("Select gender : ");
                    int genderSelection = 0;
                    if (!Int32.TryParse(Console.ReadLine(), out genderSelection))
                    {
                        Console.WriteLine("\nPlease enter valid digits only");
                        goto GenderChoices;
                    }
                    switch (genderSelection)
                    {
                        case 1:
                            gender = "Male";
                            break;
                        case 2:
                            gender = "Female";
                            break;
                        case 3:
                            gender = "Other";
                            break;
                        default:
                            Console.WriteLine("\nPlease choose valid gender");
                            break;
                    }
                    if (gender != null)
                    {
                        break;
                    }
                }
                Console.Write("Enter city : ");
                string city = Console.ReadLine();
            PhoneNo:
                Console.Write("Enter phone number : ");
                long phone = 0;
                if (!Int64.TryParse(Console.ReadLine(), out phone))
                {
                    Console.WriteLine("Invalid phone number");
                    goto PhoneNo;
                }
            MailId:
                Console.Write("Enter mail id : ");
                string userMmailId = Console.ReadLine();
                Console.Write("Enter password : ");
                string userPassword = Console.ReadLine();

                User newUser = new User()
                {
                    Name = name,
                    Gender = gender,
                    City = city,
                    Phone = phone,
                    MailId = userMmailId,
                    Password = userPassword
                };

                AuthenticationBLL registration = new AuthenticationBLL();
                int status = registration.CreateNewUser(newUser);
                if (status == 1)// 1=> registration successfull
                {
                    Console.WriteLine("\nRegistration successfull, Login to continue\n");
                    Login();
                }
                else if (status == 2)// 2=> Mail id already exist
                {
                    Console.WriteLine("\nMail id already exist... Try again\n");
                    goto MailId;
                }
                else if (status == 3)// 3=> Null value encountered
                {
                    Console.WriteLine("\nNull values are not alowed\n");
                    Register();
                }
                else
                {
                    Register();
                }
            }
            catch (RegistrationFailedException rfe)
            {
                Console.WriteLine(rfe.Message);
                Register();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex.Message);
            }
        }
    }
}

