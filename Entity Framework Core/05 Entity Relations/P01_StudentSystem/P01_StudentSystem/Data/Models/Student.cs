using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public string Birthday { get; set; }


    }
}
