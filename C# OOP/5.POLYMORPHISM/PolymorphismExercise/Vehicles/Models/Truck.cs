using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Truck : Vehicle
    {
        private const double truckAdditionalConsumption = 1.6;
        private const double truckFuelMultiplier = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }
        public override double FuelConsuptionPerKm
        {
            get => base.FuelConsuptionPerKm;
            protected set
            {
                base.FuelConsuptionPerKm = value + truckAdditionalConsumption;
            }
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters * truckFuelMultiplier);
        }
    }
}
