
using System.Xml.Serialization;

namespace CarDealer.Dto.Export
{
    [XmlType("car")]
   public class ExportCarsWithDistanceDto
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance{ get; set; }
    }
}
