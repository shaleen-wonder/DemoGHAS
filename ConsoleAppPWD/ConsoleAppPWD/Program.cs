//create the main class and main method in the Program.cs file
using System;
using System.Data.SqlClient; // Add this using directive for SqlConnection

namespace ConsoleAppPWD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starts here!");

            //ask to enter the user name and password
            Console.WriteLine("Enter your username:");
            string? username = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string? password = Console.ReadLine();

            //check if the password is empty or else initialize with "MySecretPassword@11"
            if (string.IsNullOrEmpty(password))
            {
                password = "SecretPassword@11";
            }

            //create the object of the LoginRequest class
            LoginRequest loginRequest = new LoginRequest(username ?? string.Empty, password);
            Console.WriteLine("Username: " + loginRequest.Username);
            Console.WriteLine("Password: " + loginRequest.Password);
        }


        public static void ConnectToAzureSQL()
        {
            // connection string for Azure SQL
            string connectionString = "Server=tcp:azsqlsrvr.database.windows.net,1433;Initial Catalog=azsqlst;Persist Security Info=False;User ID=your_username;Password=P@ssword@77;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            try
            {
                // create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // open the connection
                    connection.Open();

                    // perform database operations here

                    // close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Azure SQL: " + ex.Message);
            }
        }

    }
}

