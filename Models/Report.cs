using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    public class Report
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Models.Issue>? IssueResults;
        public List<Models.Project>? ProjectResults;
        public List<Models.User>? UserResults;
    }
}
