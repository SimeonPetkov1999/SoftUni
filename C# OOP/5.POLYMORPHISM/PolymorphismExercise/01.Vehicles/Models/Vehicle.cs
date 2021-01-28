using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsuption;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsuption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsuptionPerKm = fuelConsuption;
            this.Multiplier = 1;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsuptionPerKm
        {
            get => this.fuelConsuption;
            protected set
            {
                this.fuelConsuption = value;
            }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            protected set
            {
                this.tankCapacity = value;
            }
        }

        protected virtual double Multiplier { get; set; }

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
            if (liters<=0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            if (liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters * Multiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
