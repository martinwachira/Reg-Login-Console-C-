using System;
using System.Collections;
using System.IO;

namespace RegentRegisterLogin
{
    /* console program to register and login users */
    /* expects string variables */
    /* Outputs messages and actions */

    // declared class to hold variable paths //
    public class Paths_
    {
        public static string usrPath = @"C:\Users\wcr\Desktop\RegentCollege\username.txt";
        public static string passPath = @"C:\Users\wcr\Desktop\RegentCollege\password.txt";
        public static string timePath = @"C:\Users\wcr\Desktop\RegentCollege\time.txt";
        public static string mainMsg = @"Welcome. What would you like to do?
                *********************
                    1 Login
                    2 Register
                    3 Shut Down
                *********************
               ";
        public static string mainUsrMsg = @"
                *********************
                    1 logout
                    2 ChangePassword
                    3 Shutdown
                *********************
                ";
    }
    
    // main class
     class Program
     {
        //<declare variables>
        string input;
        int ID = 0;
        bool login = false;

        string usrP = Paths_.usrPath;
        string passP = Paths_.passPath;
        string tP = Paths_.timePath;
        string mMs = Paths_.mainMsg;
        string mUmsg = Paths_.mainUsrMsg;

        // Declare Method RegisterLogin with the logic
        public void RegisterLogin()
        {
            try
            {
                string[] usernameArray = File.ReadAllLines(usrP);
                ArrayList username = new ArrayList(usernameArray);
                string[] passwordArray = File.ReadAllLines(passP);
                ArrayList password = new ArrayList(passwordArray);
                string[] timeArray = File.ReadAllLines(tP);
                ArrayList time = new ArrayList(timeArray);

            start:
                if (login == true)
                {
                    goto menu;
                }
                Console.Clear();
                Console.WriteLine(mMs);
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                    case "login":
                        Console.WriteLine("What is your username?");
                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "default")
                        {
                            Console.WriteLine("Please try another user name");
                            Console.WriteLine("Please try another user name");
                            Console.ReadKey();
                            goto start;
                        }

                        //loops through the username list
                        foreach (string name in username)
                        {
                            //returns true a match is found
                            if (name == input)
                            {
                                //sets the list to the index number of the password list that matched
                                int listNo = username.IndexOf(input);
                                Console.WriteLine("What is your password?");
                                input = Console.ReadLine();
                                string passCheck = Convert.ToString(password[listNo]);

                                //user gets logged in once the credentials match
                                if (input == passCheck) 
                                {
                                    ID = listNo;//sets the user id
                                    string lastLogin = Convert.ToString(time[ID]);//gets the last login from the time list
                                    Console.WriteLine(@"You logged in! You last logged in at " + lastLogin);
                                    time[ID] = (Convert.ToString(DateTime.Now));//sets a new login time
                                    using (TextWriter writer = File.CreateText(tP))//creates a txt file called time
                                    {
                                        foreach (string date in time)
                                        {
                                            writer.WriteLine(date);//adds a new line to the txt file for time
                                        }
                                    }
                                    Console.ReadKey();
                                    login = true;
                                    goto start;
                                }
                            }
                        }
                        Console.WriteLine("We can't authorize this user, Please check your credentials!");
                        Console.ReadKey();
                        goto start;

                    case "2":
                    case "register":

                        Console.WriteLine("What would you like your new username to be?");
                    username:
                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "")
                        {
                            Console.WriteLine("Please input a username");
                            goto username;
                        }
                        foreach (string name in username)
                        {
                            if (name == input)//checks if there is a user name called that already
                            {
                                Console.WriteLine("Sorry this username is taken");
                                Console.ReadKey();
                                goto start;
                            }
                        }
                        username.Add(input);//adds the username to the username list
                        Console.WriteLine("What would you like your password to be?");
                    password:
                        input = Console.ReadLine();
                        if (input == "")
                        {
                            Console.WriteLine("Please enter a password");
                            goto password;
                        }
                        password.Add(input);//adds the password to the password list
                        using (TextWriter writer = File.CreateText(usrP))//creates a txt file called username
                        {
                            foreach (string name in username)
                            {
                                writer.WriteLine(name);//adds a new line to the txt file for the user
                            }
                        }
                        using (TextWriter writer = File.CreateText(passP))
                        {
                            foreach (string pass in password)
                            {
                                writer.WriteLine(pass);
                            }
                        }
                        time.Add(Convert.ToString(DateTime.Now));
                        using (TextWriter writer = File.CreateText(tP))//creates a txt file called username
                        {
                            foreach (string date in time)
                            {
                                writer.WriteLine(date);//adds a new line to the txt file for the user
                            }
                        }
                        Console.WriteLine("User created, proceed to Login!");
                        Console.ReadKey();
                        break;

                    case "3":
                    case "shutdown":
                        Console.Clear();
                        Console.WriteLine("Shutting down...");
                        Console.ReadKey();
                        Environment.Exit(0);//closes down the console
                        break;

                    default:
                        Console.WriteLine("Unexpected input");
                        Console.ReadKey();
                        break;
                }
                goto start;

            menu:
                Console.Clear();

                string user = Convert.ToString(username[ID]);
                Console.WriteLine(@"Main menu Welcome back " + user);
                Console.WriteLine(mUmsg);
                input = Console.ReadLine();
                input.ToLower();
                switch (input)
                {
                    case "1":
                    case "logout":
                        Console.WriteLine("Would you like to logout? y/n");
                        input = Console.ReadLine();
                        if (input == "y")
                        {
                            login = false;
                            ID = 0;
                            Console.WriteLine("Logged out");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                    case "changepassword":
                        Console.WriteLine("What would you like your new password to be?");
                        input = Console.ReadLine();
                        password[ID] = input;
                        using (TextWriter writer = File.CreateText(passP))
                        {
                            foreach (string pass in password)
                            {
                                writer.WriteLine(pass);
                            }
                        }
                        Console.WriteLine("Password changed!");
                        Console.ReadKey();
                        break;

                    case "3":
                    case "shutdown":
                        Console.Clear();
                        Console.WriteLine("Shutting down...");
                        Console.ReadKey();
                        Environment.Exit(0);//closes down the console
                        break;

                    default:
                        Console.WriteLine("Unexpected input");
                        Console.ReadKey();
                        break;
                }
                goto start;
            }
            catch
            {
                Console.Write("Some error occured. Please try again");
            }
        }

        // main method
        static void Main(string[] args)
        {
            // create object of class Program
            Program prog = new Program();

            // handle errors here
            try
            {
                // call RegisterLogin method here
                prog.RegisterLogin();
            }
            catch
            {
                Console.Write("Error Occured");
            }
        }
    }
}