using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Tire
    {
        public double TirePressure { get; set; }
        public double TireAge { get; set; }

        public Tire() 
        {
            this.TirePressure = 0;
            this.TireAge = 0;
        }
        public Tire(double pressure, double age) 
        {
            this.TirePressure = pressure;
            this.TireAge = age;
        }
    }
}
