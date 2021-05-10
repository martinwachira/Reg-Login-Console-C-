using System;
using System.Collections.Generic;

namespace RegistrationLoginProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static List<string> nm = new List<string>();
        public static List<string> password = new List<string>();
        public static bool startup = true;
        public static bool logged = false;

        public static void Start()
        {
            string choice;

            while (startup == true)
            {

                Console.WriteLine("What would you wish you to do? \n 1. Register \n 2. Login");

                choice = Console.ReadLine();

                //loop through the options
                switch (choice)
                {
                    case "1":
                    case "register":
                        Register();
                        break;
                    case "2":
                    case "login":
                        Login(ref logged, out startup);
                        break;
                    default:
                        Console.WriteLine("Some Error occured, please try again.");
                        Console.WriteLine();
                        break;
                }

            }

        }

        //Logged in loop
        public static void Run()
        {

            string app;

            while (logged == true)
            {
                Console.WriteLine("\n \n Choose an option: \n 1. Main Menu \n 2. Logout \n 3. Exit. \n ");
                Console.WriteLine(" ************************************************************* \n ");
                app = Console.ReadLine();

                if (app == "1")
                {
                    MainMenu();
                }
                else if (app == "3")
                {
                    Console.WriteLine("Goodbye. See you again soon");
                    logged = false;
                }
                else if (app == "2")
                {
                    logged = false;
                    startup = true;
                    Console.WriteLine();
                    Start();
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine();
                }

            }

        }

        //Registration method
        public static void Register()
        {
            Console.WriteLine("Input your username: ");
            nm.Add(Console.ReadLine());
            Console.WriteLine("Input your password: ");
            password.Add(Console.ReadLine());
            Console.WriteLine();
        }

        //Login method
        public static bool Login(ref bool logged, out bool startup)
        {
            string username;
            string pwd;

            Console.WriteLine("Write your username");
            username = Console.ReadLine();

            foreach (string name in nm)
            {

                if (name == username)
                {
                    Console.WriteLine("Write your Password");
                    pwd = Console.ReadLine();

                    foreach (string pword in password)
                    {
                        if (pword == pwd)
                        {
                            Console.WriteLine(" \n \n You are logged in");
                            Console.WriteLine();
                            logged = true;
                            startup = false;
                            Run();
                            return logged;
                        }

                    }
                    Console.WriteLine("Incorrect Password");
                    Console.WriteLine();
                    startup = true;
                    return logged;
                }
            }

            Console.WriteLine("Invalid username");
            Console.WriteLine();
            startup = true;
            return logged;
        }

        // main menu
        public static void MainMenu()
        {
            Console.WriteLine("You have successfully executed the program \n This is the main Page. \n \n ");
        }

    }
}
