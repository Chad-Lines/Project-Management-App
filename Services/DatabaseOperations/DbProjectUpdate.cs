using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Services.DatabaseOperations
{
    internal class DbProjectUpdate
    {
        // Create Operation
        private static bool Add(Models.ProjectUpdate projectUpdate)
        {
            return false;
        }

        #region Read Operations
        private static List<Models.ProjectUpdate> GetAll()
        {
            List<Models.ProjectUpdate> ProjectUpdates = new List<Models.ProjectUpdate>();
            return ProjectUpdates;
        }

        private static List<Models.ProjectUpdate> GetAllPerProject(int projectId)
        {
            List<Models.ProjectUpdate> ProjectUpdates = new List<Models.ProjectUpdate>();
            return ProjectUpdates;
        }

        private static List<Models.ProjectUpdate> GetAllCreatedByUser(int userId)
        {
            List<Models.ProjectUpdate> ProjectUpdates = new List<Models.ProjectUpdate>();
            return ProjectUpdates;
        }
        #endregion

        // Update Operation
        private static bool Update(int projectUpdateId, Models.ProjectUpdate projectUpdate)
        {
            return false;
        }

        // Delete Operations
        private static bool Delete(int projectUpdateId)
        {
            return false;
        }
    }
}
