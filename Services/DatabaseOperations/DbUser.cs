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
        // Create Operation
        public static bool Add(int Id, Models.User user)
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

        #region Read Operations
        private static List<Models.User> GetAll()
        {
            List<Models.User> Users = new List<Models.User>();
            return Users;
        }

        private static List<Models.User> GetAllPerGroup(int groupId)
        {
            List<Models.User> Users = new List<Models.User>();
            return Users;
        }
        #endregion

        // Update Operation
        private static bool Update(int id, Models.User user)
        {
            return false;
        }

        // Delete Operations
        private static bool Delete(int id)
        {
            return false;
        }
    }
}
