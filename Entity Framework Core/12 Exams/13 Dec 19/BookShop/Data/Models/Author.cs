using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
   public class Author
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        [Range(3,30)]
        public string FirstName { get; set; }
        [Required]
        [Range(3,30)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d{3}[-]\d{3}[-]\d{4}")]
        public string Phone { get; set; }

        public ICollection<AuthorBook> AuthorsBooks  { get; set; }
    }
}
