using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Data.Models
{
   public class Employee
    {
        public int  Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }


    }
}
