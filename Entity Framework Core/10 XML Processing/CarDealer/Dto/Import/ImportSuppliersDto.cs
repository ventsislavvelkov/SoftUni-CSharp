using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Supplier")]
    public class ImportSuppliersDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }

    }
}

