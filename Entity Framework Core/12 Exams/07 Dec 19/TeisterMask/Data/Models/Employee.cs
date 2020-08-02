
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TeisterMask.Data.Models
{
   public class Employee
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        [Range(3,40)]
        [RegularExpression(@"[^a-z]|[^A-Z][0-9]")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d{3}[-]\d{3}[-]\d{4}")]
        public int Phone { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }


    }
}
