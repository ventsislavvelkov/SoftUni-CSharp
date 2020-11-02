using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Repository
    {
        [Key]
        public string Id { get; set; }
        = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }


        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; }
        = new HashSet<Commit>();
        
    }
}