using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("suplier")]
    public class LocalSupplier
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
