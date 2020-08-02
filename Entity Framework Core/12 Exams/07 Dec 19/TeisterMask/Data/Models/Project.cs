using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
  public  class Project
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
