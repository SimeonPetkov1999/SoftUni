using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    //<Car>
    //<make>Opel</make>
    //<model>Omega</model>
    //<TraveledDistance>176664996</TraveledDistance>
    //<parts>
    //  <partId id = "38" />
    //  < partId id="102"/>
    //  <partId id = "23" />

    [XmlType("Car")]
    public class CarPartDto
    {
        public string make { get; set; }

        public string model { get; set; }

        public int TraveledDistance { get; set; }

        [XmlArray]
        public PartDto[] parts { get; set; }
    }

    [XmlType("partId")]
    public class PartDto
    {
        [XmlAttribute]
        public int id { get; set; }
    }
}
