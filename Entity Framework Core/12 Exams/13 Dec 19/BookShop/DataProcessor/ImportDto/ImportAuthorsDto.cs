using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    
   public class ImportAuthorsDto
    {

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        [XmlElement("Phone")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [XmlElement("Email")]
        public string Email { get; set; }
        [XmlElement("Books")]
        public ImportBookAuthorsDto[] Books  { get; set; }
    }

   [XmlType("Books")]
   public class ImportBookAuthorsDto
   {
       [XmlElement("Id")]
       public int Id { get; set; }
   }
}
