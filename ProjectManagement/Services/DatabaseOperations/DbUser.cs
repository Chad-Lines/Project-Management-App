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
    internal class DbUser
    {
        // Create Operation
        private static bool Add(Models.User user)
        {
            return false;
        }

        #region Read Operations
        private static List<Models.User> GetAll()
        {
            List<Models.User> Users = new List<Models.User>();
            return Users;
        }

        private static List<Models.User> GetAllPerGroup(int groupId)
        {
            List<Models.User> Users = new List<Models.User>();
            return Users;
        }
        #endregion

        // Update Operation
        private static bool Update(int id, Models.User user)
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
