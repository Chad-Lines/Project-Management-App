using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using System.Windows.Forms;

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

        // NOTE: By default the log is stored in \ProjectManagement\bin\Debug\log.csv
        public static void Add(string msgTxt, string type, Object obj = null)
        {
            string strJson = JsonSerializer.Serialize(obj);         // Serializing the object
            string filePath = "log.txt";                            // The path to the log 

            string msg = $"{type}: {DateTime.Now.ToString()}, " +     // The message to log
                $"Message: {msgTxt}, Object:{strJson}" +
                Environment.NewLine;

            File.AppendAllText(filePath, msg);                      // Appending the message to the log file
        }
    }
}
