using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerAlbumsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
    }
}
