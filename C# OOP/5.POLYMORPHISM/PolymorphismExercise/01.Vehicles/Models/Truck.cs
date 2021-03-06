﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Truck : Vehicle
    {
        private const double truckAdditionalConsumption = 1.6;
        private const double truckFuelMultiplier = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
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

        protected override double Multiplier 
        { 
            get => base.Multiplier; 
            set => base.Multiplier = truckFuelMultiplier;
        }
    }
}
