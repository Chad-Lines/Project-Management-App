using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    public class AuditEntry
    {
        public int Id { get; set; }
        public DateTime LoggedDate { get; set; }
        public int UserId { get; set; }
        public string EventType { get; set; }
        public string TargetObjectName { get; set; }
        public string TargetObjectType { get; set; }
        public string SqlCommand { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
