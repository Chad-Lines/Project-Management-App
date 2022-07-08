using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProjectManagement.Models
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }        
        public int ProjectId { get; set; }
        public int CreatedUserId { get; set; }
        public int? AssignedUserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }        
        public string? Notes { get; set; }
    }
}
