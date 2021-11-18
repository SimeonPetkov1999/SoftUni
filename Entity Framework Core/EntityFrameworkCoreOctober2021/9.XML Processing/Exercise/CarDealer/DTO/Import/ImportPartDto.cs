using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    //<Part>
    //    <name>Bonnet/hood</name>
    //    <price>1001.34</price>
    //    <quantity>10</quantity>
    //    <supplierId>17</supplierId>
    //</Part>

    [XmlType("Part")]
    public class ImportPartDto
    {
        public string name { get; set; }
        public decimal price { get; set; }

        public int quantity { get; set; }

        public int supplierId { get; set; }
    }
}
