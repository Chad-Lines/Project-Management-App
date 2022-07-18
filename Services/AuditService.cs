using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Services
{
    public static class AuditService
    {
        // The audit service writes database events to the database, while the log service writes
        // ALL events to a local log file
        public static bool Add( int userId,  string eventType, string targetObjectName, 
            string targetObjectType, string sqlCommand, bool isSuccessful)
        {
            return true;
        }

        public static List<Models.AuditEntry> Read()
        {
            return new List<Models.AuditEntry>();
        }
    }
}
