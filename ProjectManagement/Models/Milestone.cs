﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProjectManagement.Models
{
    public class Milestone : Task
    {
        public string Category { get; set; }
    }
}
