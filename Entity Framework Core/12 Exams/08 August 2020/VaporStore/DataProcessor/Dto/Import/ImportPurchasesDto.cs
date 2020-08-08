using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchases")]
  public  class ImportPurchasesDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Game { get; set; }
        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        [XmlElement("Key")]
        public string Key { get; set; }
        [Required]
        [XmlElement("Card")]
        public string Card { get; set; }
        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
        
    }
}
