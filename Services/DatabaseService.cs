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
    public static class DatabaseService
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

        // Convert from UTC to local so that we can display them per the users' time zone
        public static DateTime ConvertToLocalTime(DateTime dt) => dt.ToLocalTime();

        // Convert times to UTC so that we can display them per the users' time zone
        public static DateTime ConvertToUtcTime(DateTime dt) => dt.ToUniversalTime();

        #endregion

        #region USER OPERATIONS
        public static bool AddUser(Models.User user) => DatabaseOperations.DbUser.Add(1, user) ? true : false;
        public static int GetUserId(string un) =>  DatabaseOperations.DbUser.GetUserId(un);
        public static Models.User GetUserById(int uid) => DatabaseOperations.DbUser.GetUserById(uid);
        public static string GetUserSalt(int id) => DatabaseOperations.DbUser.GetUserSalt(id);
        public static string GetUserPasswordHash(int id) => DatabaseOperations.DbUser.GetUserPasswordHash(id);

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
