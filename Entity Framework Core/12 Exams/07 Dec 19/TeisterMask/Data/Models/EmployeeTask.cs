using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        [Required]
        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
