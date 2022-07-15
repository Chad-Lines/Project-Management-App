using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    public class IssueUpdate
    {
        public int Id { get; set; }
        public int RelatedIssueId { get; set; }
        public int UpdatedByUserId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        // Universal --
        public string CreatedDate { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string ModifiedDate { get; set; } = string.Empty;
        public int ModifiedByUserId { get; set; }

    }
}
