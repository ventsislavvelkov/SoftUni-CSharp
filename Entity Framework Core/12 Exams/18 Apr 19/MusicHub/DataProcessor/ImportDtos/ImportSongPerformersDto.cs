using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    class ImportSongPerformersDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [Range(18,70)]
        [XmlElement("Age")]
        public int Age { get; set; }
        [Range(0, 10000000)]
        [XmlElement("NetWorth")]
        public decimal  NetWorth { get; set; }
        [XmlArray("PerformersSongs")]
        public ImportPerformersSongsDto[] PerformersSongs { get; set; }

    }

    [XmlType("Song")]
    public class ImportPerformersSongsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
