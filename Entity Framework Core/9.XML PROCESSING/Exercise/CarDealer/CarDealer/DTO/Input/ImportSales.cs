using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("Sale")]
    public class ImportSales
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }
    }

    //<Sale>
    //    <carId>105</carId>
    //    <customerId>30</customerId>
    //    <discount>30</discount>
    //</Sale>
}
