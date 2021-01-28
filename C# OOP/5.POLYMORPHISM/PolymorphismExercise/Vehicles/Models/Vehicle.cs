using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsuption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsuptionPerKm = fuelConsuption;
        }

        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsuptionPerKm { get; protected set; }

        public virtual string Drive(double km)
        {
            double fuelNeeded = km * this.FuelConsuptionPerKm;
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.refuelExeption, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {km} km";
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
