using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace Project_Management.Services
{
    public class DatabaseService
    {
        // This is the database connection string 
        public static readonly string _constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        #region Administrative Functions
        public static MySqlConnection DbConnect()
        {
            MySqlConnection conn = new MySqlConnection(_constr);    // Create the connection using the connection string in the DataBase class
            try { conn.Open(); }                                    // Try to open the database connection
            catch (Exception ex) { Console.WriteLine(ex.Message); } // Display any errors
            return conn;                                            // Return the connection 
        }

        public static void TurnOffForeignKeyChecks()
        {
            string query = "set foreign_key_checks=0;";                 // Set foreign key checks to 0
            using (var command = new MySqlCommand(query, DbConnect()))  // Open the connection
            {
                command.ExecuteNonQuery();                              // Execute the query
            }
        }

        public static DateTime ConvertToLocalTime(DateTime dt)
        {
            // Convert from UTC to local so that we can display them per the users'
            // time zone
            DateTime localTime = dt.ToLocalTime();
            return localTime;
        }

        public static DateTime ConvertToUtcTime(DateTime dt)
        {
            // Convert times to UTC so that we can display them per the users'
            // time zone
            DateTime dateTime = dt.ToUniversalTime();
            return dateTime;
        }
        #endregion

        #region USER OPERATIONS
        public static bool AddUser(Models.User user)
        {
            // Try to pass the user over to the DbUser.Add function
            // and then return whether or not it was successful
            if (DatabaseOperations.DbUser.Add(1, user)) return true;
            else return false;
        }

        public static int GetUserId(string un)
        {
            return DatabaseOperations.DbUser.GetUserId(un);
        }

        public static string GetUserSalt(int id)
        {
            return DatabaseOperations.DbUser.GetUserSalt(id);
        }

        public static string GetUserPasswordHash(int id)
        {
            return DatabaseOperations.DbUser.GetUserPasswordHash(id);
        }

        #endregion

        #region PROJECT OPERATIONS

        #endregion

        #region MILESTONE OPERATIONS

        #endregion

        #region TASK OPERATIONS

        #endregion

        #region SUBTASK OPERATIONS

        #endregion

        #region UPDATE OPERATIONS

        #endregion

        #region REPORTING OPERATIONS

        #endregion

    }
}
