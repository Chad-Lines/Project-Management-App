using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Project_Management.Services
{
    public class LogService
    {
        /// <summary>
        ///     The log service writes ALL events to a local log file, while the audit service
        ///     writes database events to the database.
        ///     - LogError: User action failed due to program error
        ///     - LogWarning: User action failed due to permissions, mistaken input, or other disallowed action
        ///     - LogInformation: Any user action
        /// </summary>
        /// <param name="str">The specific message to include in the log</param>
        /// <param name="obj">The object related to the log</param>
        
        // NOTE: By default the log is stored in \ProjectManagement\bin\Debug\log.txt

        public static void LogError(string str, Object obj = null)
        {
            string strJson = JsonSerializer.Serialize(obj);     // Serializing the object
            string filePath = "log.txt";                        // The path to the log 

            string msg = $"ERROR: {DateTime.Now.ToString()}, " +// The message to log
                $"Message: {str}, Object:{obj}";           

            File.AppendAllText(filePath, msg);                  // Appending the message to the log file
        }

        public static void LogWarning(string str, Object obj = null)
        {
            string strJson = JsonSerializer.Serialize(obj);         // Serializing the object
            string filePath = "log.txt";                            // The path to the log 

            string msg = $"WARNING: {DateTime.Now.ToString()}, " +  // The message to log
                $"Message: {str}, Object:{obj}";

            File.AppendAllText(filePath, msg);                      // Appending the message to the log file
        }

        public static void LogInfo(string str, Object obj = null)
        {
            string strJson = JsonSerializer.Serialize(obj);             // Serializing the object
            string filePath = "log.txt";                                // The path to the log 

            string msg = $"INFORMATION: {DateTime.Now.ToString()}, " +  // The message to log
                $"Message: {str}, Object:{obj}";

            File.AppendAllText(filePath, msg);                          // Appending the message to the log file
        }

        #region NOT USED

        public static bool WriteLoginEvent(string username, bool success)
        {
            try
            {
                string msg;                                                 // String to hold the final log message
                string filePath = "log.txt";                                // The path to the log
                string loginSuccess = $"\n{DateTime.Now.ToString()} - " +   // The successful login message
                    $"Username: {username}, Message: Login Successful.";
                string loginFail = $"\n{DateTime.Now.ToString()} - " +      // The unsuccessful login message
                    $"Username: {username}, Message: Login Failed.";

                if (success) { msg = loginSuccess; }                        // Setting the appropriate message
                else { msg = loginFail; }

                File.AppendAllText(filePath, msg);                          // Appending the message to the log file
                return true;                                                // Return true if all this worked
            }
            catch
            {
                return false;                                               // Return false if there were any issues
            }
        }
        public static bool WriteUserCreatedEvent(Models.User user, string username)
        {
            try
            {
                string filePath = "log.txt";                                    // The path to the log 
                string msg = $"\n{DateTime.Now.ToString()} - " +                // The user creation log message
                    $"Username: {user.UserName}, Message: {user.UserName} " +
                    $"created new user with username: {username}.";

                File.AppendAllText(filePath, msg);                              // Appending the message to the log file
                return true;
            }
            catch
            {
                string errorMsg = $"Failed attempt to create user {username}."; // The message to send to LogError
                LogError(errorMsg, user);                                       // Logging the error
                return false;                                                   // returning false
            }
        }
        #endregion
    }
}
