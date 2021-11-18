using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("car")]
    public class CarParts
    {
        [XmlAttribute]
        public string make { get; set; }

        [XmlAttribute]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        public PartDto[] parts { get; set; }

    }

    [XmlType("part")]
    public class PartDto 
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public decimal price { get; set; }
    }
}
