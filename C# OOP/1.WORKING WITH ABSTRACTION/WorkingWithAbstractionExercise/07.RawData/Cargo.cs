using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        public double CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(double weigth, string type) 
        {
            this.CargoWeight = weigth;
            this.CargoType = type;
        }
    }
}
