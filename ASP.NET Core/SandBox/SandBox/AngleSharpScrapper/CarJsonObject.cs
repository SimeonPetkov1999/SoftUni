using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleSharpScrapper
{
    public class CarJsonObject
    {
        public string Link { get; set; }
        public string SaleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string VehicleType { get; set; }
        public string PetrolType { get; set; }
        public int KM { get; set; }
        public string GearsType { get; set; }
        public int HorsePower { get; set; }
        public int EngineCubicCm { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public ICollection<string> Extras { get; set; }
        public ICollection<string> ImgUrls { get; set; }
    }
}
