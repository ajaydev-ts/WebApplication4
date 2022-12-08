using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class Employee
    {
        public int Empid { get; set; }
        public string? Name { get; set; }
        public int? Deptid { get; set; }
        public int? Age { get; set; }

        public virtual Department? Dept { get; set; }
    }
}
