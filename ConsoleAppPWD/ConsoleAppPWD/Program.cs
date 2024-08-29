//create the main class and main method in the Program.cs file
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Data.SqlClient;
using System.IO.Compression; // Add this using directive for SqlConnection

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

            //call the method to connect Azure Storage Account
            ConnectToAzureStorage();

            //call the method to connect Azure SQL
            ConnectToAzureSQL();

            //call write to directory method
            string zipFilePath = @"C:\Users\Public\Documents\sample.zip";
            ZipArchiveEntry zipArchiveEntry = ZipFile.Open(zipFilePath, ZipArchiveMode.Read).Entries[0];

            string destDirectory = @"C:\Users\Public\Documents\unzip";
            WriteToDirectory(zipArchiveEntry, destDirectory);

            Console.WriteLine("Program ends here!");

        }


        public static void WriteToDirectory(ZipArchiveEntry entry, string destDirectory)
        {
            string destFileName = Path.Combine(destDirectory, entry.FullName);
            entry.ExtractToFile(destFileName);
        }

        //create a method to connect Azure storage account this will raise the commit issue
        public static void ConnectToAzureStorage()
        {
            // connection string for Azure Storage Account
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=calendarst;AccountKey=jzHuUupI5GPv0/uNLpgPnHbaqr3bd9Ukp6M8uM35J9ZawKEW9w8yeuwIWTAZCY9U47PsASWGAN35+AStQ0UqmQ==;EndpointSuffix=core.windows.net";

            try
            {
                // create a CloudStorageAccount object with the connection string
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

                //create a CloudBlobClient object from the storage account
               CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // perform blob operations here
                Console.WriteLine("Connected to Azure Storage successfully."); // Added to use the connectionString variable
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Azure Storage: " + ex.Message);
            }
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

