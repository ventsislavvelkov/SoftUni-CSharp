using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookShop.Data.Models.Enums;

namespace BookShop.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(3,30)]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Range(0.01, 20000000)]
        public decimal Price { get; set; }
        [Range(50,5000)]
        public int Page { get; set; }
        [Required]
        public DateTime PublishedOn { get; set; }

        public ICollection<AuthorBook> AuthorsBooks  { get; set; }
    }
}
