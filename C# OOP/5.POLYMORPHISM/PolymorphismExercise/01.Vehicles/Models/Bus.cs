using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsuption, double tankCapacity) 
            : base(fuelQuantity, fuelConsuption+=1.4, tankCapacity)
        {
        }

        public string DriveEmpty(double km) 
        {
            if (km > this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.refuelExeption, this.GetType().Name));
            }
            this.FuelQuantity -= km;
            return $"{this.GetType().Name} travelled {km} km";
        }
    }
}
