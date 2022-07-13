using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    internal class LogService
    {
        // The log service writes ALL events to a local log file, while the audit service
        // writes database events to the database
        // NOTE: By default the log is stored in \ProjectManagement\bin\Debug\log.txt

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
                return false;
            }
        }
    }
}
