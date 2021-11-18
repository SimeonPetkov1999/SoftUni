using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("car")]
    public class CarWithDistance
    {
        public string make { get; set; }
        public string model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }

    }
}
