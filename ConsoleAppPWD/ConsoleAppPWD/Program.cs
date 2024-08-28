//create the main class and main method in the Program.cs file
using System;

namespace ConsoleAppPWD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starts here!");

            //ask to enter the user name and password
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            //create the object of the LoginRequest class
            LoginRequest loginRequest = new LoginRequest(username, password);
            Console.WriteLine("Username: " + loginRequest.Username);
            Console.WriteLine("Password: " + loginRequest.Password);
            
        }
    }
}
