using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
   public class ImportSongsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }
        [Required]
        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; }
        [Required]
        [XmlElement("Genre")]
        public string Gender { get; set; }
        [XmlElement("AlbumId")]
        public int AlbumId { get; set; }
        [XmlElement("WriterId")]
        public int WriterId { get; set; }
        [Range(0,10000000)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

    }
}
