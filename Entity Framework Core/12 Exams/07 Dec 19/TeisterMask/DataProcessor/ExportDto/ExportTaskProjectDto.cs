using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
   public class ExportTaskProjectDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Label")]
        public string LabelType { get; set; }
    }
}
