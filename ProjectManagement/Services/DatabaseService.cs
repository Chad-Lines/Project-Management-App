using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProjectManagement.Services
{
    public class DatabaseService
    {

        private static SQLiteAsyncConnection _conn;

        static async Task Init()
        {
            // Initializing the database

            // Setting the path to the database
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        }

        #region USER OPERATIONS

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