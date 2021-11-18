using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Supplier")]
    public class ImportSupplierDto
    {
        public string name { get; set; }

        public bool isImporter { get; set; }
    }
}
