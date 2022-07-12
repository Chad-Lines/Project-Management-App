using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace ProjectManagement.Services.DatabaseOperations
{
    internal class DbIssue
    {
        // Create Operation
        private static bool Add(Models.Issue issue)
        {
            return false;
        }

        #region Read Operations
        private static List<Models.Issue> GetAll()
        {
            List<Models.Issue> issues = new List<Models.Issue>();
            return issues;
        }

        private static List<Models.Issue> GetAllPerProject(int projectId)
        {
            List<Models.Issue> issues = new List<Models.Issue>();
            return issues;
        }

        private static List<Models.Issue> GetAllAssignedToUser(int userId)
        {
            List<Models.Issue> issues = new List<Models.Issue>();
            return issues;
        }

        private static List<Models.Issue> GetAllCreatedByUser(int userId)
        {
            List<Models.Issue> issues = new List<Models.Issue>();
            return issues;
        }

        #endregion

        // Update Operation
        private static bool Update(int id, Models.Issue issue)
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
