using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Universal --
        public string CreatedDate { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string ModifiedDate { get; set; } = string.Empty;
        public int ModifiedByUserId { get; set; }
    }
}
