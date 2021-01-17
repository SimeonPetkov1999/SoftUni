using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar : Car
    {
       

        private double defaultFuelConsumption = 10;

        public override double FuelConsumption
        {
            get => this.defaultFuelConsumption;
            set => this.FuelConsumption = this.defaultFuelConsumption;
        }
        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
