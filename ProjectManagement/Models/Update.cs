using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProjectManagement.Models
{
    internal class Update
    {
        public int Id { get; set; }
        public int CreatedUserId { get; set; }
        public int ProjectId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

    }
}
