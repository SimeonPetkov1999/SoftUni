using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    
    public class FinalUsersDTO 
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public List<UsersAndProductsDTO> Users { get; set; }
    }

    [XmlType("User")]
    public class UsersAndProductsDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProducts SoldProducts { get; set; }
    }

    
    public class SoldProducts 
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ProductsDTO> Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductsDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
