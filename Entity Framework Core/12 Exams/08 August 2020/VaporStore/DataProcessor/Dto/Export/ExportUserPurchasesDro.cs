using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
  public class ExportUserPurchasesDro
    {
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlArray("Purchases")]
        public ExportPurchaseDto[] Type { get; set; }
    }
    [XmlType("Purchase")]
  public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }
        [XmlElement("Cvc")]
        public string Cvc { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
        [XmlArray("Game ")]
        public ExportGameDto[] Game { get; set; }
    }

  public class ExportGameDto
  {
      [XmlAttribute("title")]
      public string Name { get; set; }
        [XmlElement("Genre")]
      public string Genre { get; set; }
      [XmlElement("Price")]
        public decimal Price { get; set; }
  }
}
