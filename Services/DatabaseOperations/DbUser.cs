using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project_Management.Services.DatabaseOperations
{
    public class DbUser
    {
        public static int _userId = 1;          // The userid
        public static string _username = "test";// the username


        // Create Operation
        public static bool Add(int Id, Models.User user)
        {
            // Used to check if the username already exists
            bool usernameExists;

            // Query to get the id based on the username
            string unQuery =
                $"select id from user " +
                $"where username = '{user.UserName}';";

            // Try to execute the query
            try
            {
                // Setting the up the db connection
                MySqlConnection conn = DatabaseService.DbConnect(); 
                DatabaseService.TurnOffForeignKeyChecks();          
                MySqlCommand cmd = new MySqlCommand(unQuery, conn);   

                // Getting the user Id from the database
                MySqlDataReader dr = cmd.ExecuteReader();          
                dr.Read();                                          
                int id = ((int)dr[0]);              
                
                // If this process is successful, then the username already exists...
                usernameExists = true;
                return false;
            }
            // If there are any problems executing the query...
            catch (Exception ex1) 
            { 
                usernameExists = false;
                // We only want to create the new user as long as the username doesn't already exist
                if (usernameExists == false)
                {
                    // Converting the local time to UTC for easy time-zone adaptation
                    DateTime createdDate = DatabaseService.ConvertToUtcTime(user.CreatedDate);
                    DateTime modifiedDate = DatabaseService.ConvertToUtcTime(user.ModifiedDate);

                    // The insert string for the user
                    string idQuery =
                        $"insert into user" +
                        $"(UserName, FirstName, LastName, Email, PasswordHash, " +
                        $"PasswordSalt, CreatedDate, CreatedByUserId, ModifyDate, " +
                        $"ModifyByUserId)" +
                        $"values ('{user.UserName}', '{user.FirstName}', '{user.LastName}', " +
                        $"'{user.Email}', '{user.PasswordHash}', '{user.PasswordSalt}', " +
                        $"@cDate, {user.CreatedByUserId}, @mDate, {user.ModifiedByUserId});"
                    ;

                    try
                    {
                        // Using the command that we create, and connecting to the database...
                        using (var command = new MySqlCommand(idQuery, DatabaseService.DbConnect()))
                        {
                            // We have to convert the DateTime so that it's compatible with MySQL, then
                            // we add in the created date and modified date parameters
                            command.Parameters.Add("@cDate", MySqlDbType.DateTime).Value = createdDate;
                            command.Parameters.Add("@mDate", MySqlDbType.DateTime).Value = modifiedDate;

                            // Execute the query
                            command.ExecuteNonQuery();

                            // ADD: LOGGING FEATURES FOR SUCCESS
                            // ADD: AUDITING FEATURES FOR SUCCESS

                            // Return that the insert was successful 
                            return true;
                        }
                    }
                    catch (Exception ex2)
                    {
                        // ADD: LOGGING FEATURES FOR FAILURE
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }                           
        }

        #region Read Operations

        public static int GetUserId(string un)
        {
            // Query to get the id based on the username
            string query =
                $"select id from user " +
                $"where username = '{un}';";

            // Try to execute the query
            try
            {
                // Setting the up the db connection
                MySqlConnection conn = DatabaseService.DbConnect(); // Getting the connection parameters
                DatabaseService.TurnOffForeignKeyChecks();          // Turn off foreign key checks (admin task)
                MySqlCommand cmd = new MySqlCommand(query, conn);   // Create the MySql query 

                // Getting the user Id from the database
                MySqlDataReader dr = cmd.ExecuteReader();           // Executing the query
                dr.Read();                                          // Capturing the output of the query
                _userId = ((int)dr[0]);                             // Assigning the _userId varible as approrpriate
                                                                    // [0] refers to the first column of the results
                // Returning the userId 
                return _userId;
            }
            // If there are any problems executing the query...
            catch (Exception ex)
            {
                Console.WriteLine(ex);  // Show the error in the console   
                return 0;               // Set the userId to 0 (a non-existant id)
            }
        }

        public static string GetUserSalt(int uid)
        {
            string query =
                $"select passwordsalt from user " +
                $"where id = {uid};";

            // Try to execute the query
            try
            {
                // Setting the up the db connection
                MySqlConnection conn = DatabaseService.DbConnect(); 
                DatabaseService.TurnOffForeignKeyChecks();          
                MySqlCommand cmd = new MySqlCommand(query, conn);   

                // Getting the user Id from the database
                MySqlDataReader dr = cmd.ExecuteReader();           
                dr.Read();                                          
                string salt = (string)dr[0];                     
                
                // Return the salt
                return salt;
            }
            // If there are any problems executing the query...
            catch (Exception ex)
            {
                Console.WriteLine(ex);  // Show the error in the console   
                return "";
            }
        }

        public static string GetUserPasswordHash(int uid)
        {
            string query =
                $"select passwordhash from user " +
                $"where id = {uid};";

            // Try to execute the query
            try
            {
                // Setting the up the db connection
                MySqlConnection conn = DatabaseService.DbConnect();
                DatabaseService.TurnOffForeignKeyChecks();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Getting the user Id from the database
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string hash = (string)dr[0];

                // Return the salt
                return hash;
            }
            // If there are any problems executing the query...
            catch (Exception ex)
            {
                Console.WriteLine(ex);  // Show the error in the console   
                return "";
            }
        }

        public static List<Models.User> GetAll()
        {
            List<Models.User> Users = new List<Models.User>();
            return Users;
        }

        public static List<Models.User> GetAllPerGroup(int groupId)
        {
            List<Models.User> Users = new List<Models.User>();
            return Users;
        }
        #endregion

        // Update Operation
        public static bool Update(int id, Models.User user)
        {
            return false;
        }

        // Delete Operations
        public static bool Delete(int id)
        {
            return false;
        }
    }
}
