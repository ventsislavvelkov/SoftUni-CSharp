using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,1000)]
        public int CellNumber { get; set; }
        [Required]
        public bool HasWindow { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<Prisoner> Prisoners { get; set; }
        = new HashSet<Prisoner>();
    }
}