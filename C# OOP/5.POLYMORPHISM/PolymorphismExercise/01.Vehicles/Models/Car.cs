﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    class Car : Vehicle
    {
        private const double carAdditionalConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {

        }
        public override double FuelConsuptionPerKm
        {
            get => base.FuelConsuptionPerKm;
            protected set
            {
                base.FuelConsuptionPerKm = value + carAdditionalConsumption;
            }
        }
    }
}
