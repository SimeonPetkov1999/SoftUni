using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{

    public class UserProducts
    {
        public int count { get; set; }

        public UserInfo[] users { get; set; }
    }

    [XmlType("User")]
    public class UserInfo 
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int? age { get; set; }

        public SoldProducts SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")]
    public class SoldProducts 
    {
        public int count { get; set; }

        public ProductInfo[] products { get; set; }
    }

    [XmlType("Product")]
    public class ProductInfo 
    {
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
