using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    public class Issue
    {
        /* NOTES ON NULLABLE VS. NON-NULLABLE
         * ----------------------------------
         * 1. The " = string.Empty;" sets the default state for this variable as empty, but retains the non-nullable nature
         * 2. The ? after the type indicates that this is a nullable field
        */
        public int Id { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int SubmittedUserId { get; set; }
        public string SubmittedDate { get; set; } = string.Empty;
        public int RelatedProjectId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string TargetResolutionDate { get; set; } = string.Empty;
        public string ActualResolutionDate { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string ModifiedDate { get; set; } = string.Empty;
        public int ModifiedByUserId { get; set; }
    }
}
