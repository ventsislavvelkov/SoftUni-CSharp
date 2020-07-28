using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Car")]
  public class ImpoortCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }
        [XmlArray("parts")]
        public PartsDto[] Parts { get; set; }
    }

  [XmlType("partId")]
  public class PartsDto
  {
      [XmlElement("id")]
      public int Id { get; set; }
  }
}

