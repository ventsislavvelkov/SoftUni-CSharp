using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Data.Models
{
  public  class Project
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }

        public ICollection<Taks> Tasks { get; set; }
    }
}
