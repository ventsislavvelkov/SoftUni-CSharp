using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Commit
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreateOn { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }

    }
}