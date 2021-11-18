using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("customer")]
    public class SalesByCustomer
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }

        [XmlAttribute("bougth-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }

    }
}
