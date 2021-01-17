using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle : Motorcycle
    {
        private double defaultFuelConsumption = 8;

        public override double FuelConsumption 
        { 
            get => this.defaultFuelConsumption; 
            set => this.FuelConsumption = this.defaultFuelConsumption; }
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
