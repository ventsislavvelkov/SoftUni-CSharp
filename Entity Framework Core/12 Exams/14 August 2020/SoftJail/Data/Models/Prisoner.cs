using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Range(18,65)]
        public int Age { get; set; }

        public DateTime IncarcerationDate  { get; set; }

        public DateTime? ReleaseDate { get; set; }
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Bail { get; set; }

        [ForeignKey(nameof(Cell))]
        public int CellId { get; set; }

        public Cell Cell { get; set; }

        public virtual ICollection<Mail> Mails { get; set; }
        = new HashSet<Mail>();

        public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
        = new HashSet<OfficerPrisoner>();

    }
}