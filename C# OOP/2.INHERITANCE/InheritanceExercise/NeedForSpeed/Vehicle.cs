using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        private double defaultFuelConsumption = 1.25;

        public virtual double FuelConsumption
        {
            get { return this.defaultFuelConsumption; }
            set { this.FuelConsumption = defaultFuelConsumption; }
        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers) 
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
