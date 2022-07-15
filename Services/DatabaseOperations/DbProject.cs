using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Services.DatabaseOperations
{
    internal class DbProject
    {
        // Create Operation
        private static bool Add(Models.Project project)
        {
            return false;
        }

        #region Read Operations
        private static List<Models.Project> GetAll()
        {
            List<Models.Project> projects = new List<Models.Project>();
            return projects;
        }

        private static List<Models.Project> GetAllPerUser(int userId)
        {
            List<Models.Project> projects = new List<Models.Project>();
            return projects;
        }
        #endregion

        // Update Operation
        private static bool Update(int id, Models.Project project)
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
