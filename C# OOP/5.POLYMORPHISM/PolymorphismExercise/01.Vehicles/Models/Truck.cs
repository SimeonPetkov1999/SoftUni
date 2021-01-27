using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption += 1.6, tankCapacity)
        {

        }

        public override void Refuel(double liters)
        {
            if (liters>this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            base.Refuel(liters*0.95);
        }
    }
}
