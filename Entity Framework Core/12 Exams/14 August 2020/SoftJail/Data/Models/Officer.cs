using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SoftJail.Data.Models.Enums;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Salary { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        public Weapon Weapon { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
        = new HashSet<OfficerPrisoner>();

    }
}