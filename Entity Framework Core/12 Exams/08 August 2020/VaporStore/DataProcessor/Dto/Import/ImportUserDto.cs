using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
   public class ImportUserDto
    {
        [Required]
        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [Range(3,103)]
        public int Age { get; set; }
        [Required]
        public List<ImportCardDto> Cards { get; set; }

    }

   public class ImportCardDto
   {
       [Required]
       [RegularExpression(@"[A-Z|0-9]{4}-[A-Z|0-9]{4}-[A-Z|0-9]{4}")]
       public string Number { get; set; }
       [Required]
        [RegularExpression(@"[0-9]{3}")]
       public string Cvc { get; set; }
        [Required]
       public string Type { get; set; }

   }
}
