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
            // Check if the username already exists
            bool usernameExists = CheckIfUsernameExists(user.UserName);

            // If the username exists, return false
            if (usernameExists == true) { return false; }

            // If the username does NOT exist, create the user
            else
            {
                // Converting the local time to UTC for easy time-zone adaptation
                DateTime createdDate = DatabaseService.ConvertToUtcTime(user.CreatedDate);
                DateTime modifiedDate = DatabaseService.ConvertToUtcTime(user.ModifiedDate);

                // The insert string for the user
                string query =
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
                    using (var command = new MySqlCommand(query, DatabaseService.DbConnect()))
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
                catch (Exception ex)
                {
                    // ADD: LOGGING FEATURES FOR FAILURE

                    // If the insert fails, then we write the failure, and return false
                    Console.WriteLine(ex);
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

        public static Models.User GetUserById(int uid)
        {
            Models.User user = new Models.User();                                       // Creating the user object

            MySqlCommand query = new MySqlCommand(                                      // Creating the query 
                $"select * from user " +
                $"where id = {uid};", 
                DatabaseService.DbConnect()
            );

            using (DatabaseService.DbConnect())                                         // Using the connection...
            {
                using (query)                                                           // Using the query...
                {
                    MySqlDataReader reader = query.ExecuteReader();                     // Execute the query
                    
                    while (reader.Read())
                    {
                        try
                        {                            
                            user.Id = Convert.ToInt32(reader[0]);
                            user.UserName = reader[1].ToString();
                            user.FirstName = reader[2].ToString();
                            user.LastName = reader[3].ToString();
                            user.Email = reader[4].ToString();
                            user.PasswordHash = reader[5].ToString();
                            user.PasswordSalt = reader[6].ToString();

                            string logMsg = $"User successfully queried with id {uid}"; // Creating the log message
                            Services.LogService.LogInfo(logMsg, user);                  // Saving the log message

                            return user;                                                // Return the user
                        }
                        catch
                        {
                            string logMsg = $"User (id: {uid} query failed";            // Creating the log message
                            Services.LogService.LogError(logMsg);                       // Saving the log message
                        }
                    }
                }
                return user;                                                            // Returning the user object
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

        #region Helper Operations
        public static bool CheckIfUsernameExists(string un)
        {
            // Query to get the count of records with this username
            string unQuery =
                $"select count(*) from user " +
                $"where username = '{un}';";            
            
            // Setting the up the db connection
            MySqlConnection conn = DatabaseService.DbConnect();
            DatabaseService.TurnOffForeignKeyChecks();
            MySqlCommand cmd = new MySqlCommand(unQuery, conn);

            // Getting the user Id from the database
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            // Casting as a long instead of an int is necessary because of mismatching types between
            // C# and MySql (the return type of count(*) is Int64. Casting as an int results in error:
            // "System.InvalidCastException: 'Unable to cast object of type 'System.Int64' to type
            // 'System.Int32'.'"
            long count = ((long)dr[0]);

            // Audit parameters
            int id = _userId;
            string eventType = "User Add";
            string targetObjectName = un;
            string targetObjectType = "User";
            string sqlCommand = unQuery;

            Services.AuditService.Add(_userId, eventType, targetObjectName, targetObjectType, sqlCommand, count > 0);

            // If the count is greater than 0 (i.e. the username exists) return true
            if (count > 0) { return true; }
            else { return false; } 
        }

        #endregion
    }
}
