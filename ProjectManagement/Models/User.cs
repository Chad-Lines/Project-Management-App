using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public HashCode PasswordHash { get; set; }
        public string PasswordSalt { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Universal --
        public string CreatedDate { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string ModifiedDate { get; set; } = string.Empty;
        public int ModifiedByUserId { get; set; }
    }
}
