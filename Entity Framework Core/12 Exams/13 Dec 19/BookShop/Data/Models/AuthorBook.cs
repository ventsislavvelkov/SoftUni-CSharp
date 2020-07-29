using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Data.Models
{
    public class AuthorBook
    {
        [Required]
        public int  AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
