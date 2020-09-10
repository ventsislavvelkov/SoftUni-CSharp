using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsCells
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        public string[] Cells { get; set; }
    }

    public class CellsDto
    {
        [Required]
        [Range(1,1000)]
        public int CellNumber { get; set; }
        [Required]
        public string HasWindow { get; set; }

    }
}