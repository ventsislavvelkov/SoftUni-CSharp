

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
  public  class ImportProjectsDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }
        [XmlElement("DueDate")]
        public string DueDate { get; set; }
        [XmlArray("Tasks")]
        public ImportTaskDto[] Task { get; set; }
    }

  [XmlType("Task")]
  public class ImportTaskDto
  {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }
        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }
        [Required]
        [XmlElement("ExecutionType")]
        public string ExecutionType { get; set; }
        [Required]
        [XmlElement("LabelType")]
        public string LabelType { get; set; }
    }
}
