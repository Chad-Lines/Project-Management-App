using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Services.DatabaseOperations
{
    internal class DbIssueUpdate
    {
        // Create Operation
        private static bool Add(Models.IssueUpdate issueUpdate)
        {
            return false;
        }

        #region Read Operations
        private static List<Models.IssueUpdate> GetAll()
        {
            List<Models.IssueUpdate> issueUpdates = new List<Models.IssueUpdate>();
            return issueUpdates;
        }

        private static List<Models.IssueUpdate> GetAllPerIssue(int projectId)
        {
            List<Models.IssueUpdate> issueUpdates = new List<Models.IssueUpdate>();
            return issueUpdates;
        }

        private static List<Models.IssueUpdate> GetAllCreatedByUser(int userId)
        {
            List<Models.IssueUpdate> issueUpdates = new List<Models.IssueUpdate>();
            return issueUpdates;
        }
        #endregion

        // Update Operation
        private static bool Update(int issueUpdateId, Models.IssueUpdate issueUpdate)
        {
            return false;
        }

        // Delete Operations
        private static bool Delete(int issueUpdateId)
        {
            return false;
        }
    }
}
