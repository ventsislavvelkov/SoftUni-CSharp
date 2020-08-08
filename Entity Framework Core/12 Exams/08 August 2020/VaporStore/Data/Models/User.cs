using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
   public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Range(3,103)]
        public int  Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        = new HashSet<Card>();
    }
}
