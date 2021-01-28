using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Bus : Vehicle
    {
        private const double busAdditionalConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsuption, double tankCapacity)
            : base(fuelQuantity, fuelConsuption, tankCapacity)
        {
        }

        public override double FuelConsuptionPerKm
        {
            get => base.FuelConsuptionPerKm;
            protected set
            {
                base.FuelConsuptionPerKm = value + busAdditionalConsumption;
            }
        }

        public string DriveEmpty(double km)
        {
            double fuelNeeded = (this.FuelConsuptionPerKm - busAdditionalConsumption) * km;
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.refuelExeption, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {km} km";
        }
    }
}
