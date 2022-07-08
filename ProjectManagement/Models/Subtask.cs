using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProjectManagement.Models
{
    public class Subtask : Task
    {
        public int SuperTaskId { get; set; }
    }
}
