using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class CategoriesCount
    {
        public string name { get; set; }

        public int count { get; set; }

        public decimal averagePrice  { get; set; }

        public decimal totalRevenue { get; set; }
    }
}
