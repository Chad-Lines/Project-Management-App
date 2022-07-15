using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string TargetEndDate { get; set; } = string.Empty;
        public string ActualEndDate { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Universal --
        public string CreatedDate { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string ModifiedDate { get; set; } = string.Empty;
        public int ModifiedByUserId { get; set; }
    }
}
