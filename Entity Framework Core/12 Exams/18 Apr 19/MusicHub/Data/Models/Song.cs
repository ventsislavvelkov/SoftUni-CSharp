using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
   public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }

        public DateTime CreateOn { get; set; }

        public Genre Genre { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
        [ForeignKey(nameof(Writer))]
        public int WriteId { get; set; }

        public virtual Writer Writer { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
        = new HashSet<SongPerformer>();
    }
}
