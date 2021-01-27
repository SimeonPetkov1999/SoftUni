using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption += 0.9,tankCapacity)
        {

        }

        //public override void Refuel(double liters)
        //{
        //    if (this.TankCapacity< this.FuelQuantity+liters)
        //    {
        //        throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank")
        //    }
        //    this.FuelQuantity += liters;
        //}
    }
}
