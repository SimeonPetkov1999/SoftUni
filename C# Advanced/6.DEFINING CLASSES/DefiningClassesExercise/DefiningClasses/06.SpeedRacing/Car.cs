using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmout { get; set; }
        public double FuelConspumtionPerKM { get; set; }
        public double TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConspumtionPerKM)
        {
            this.Model = model;
            this.FuelAmout = fuelAmount;
            this.FuelConspumtionPerKM = fuelConspumtionPerKM;
            this.TraveledDistance = 0;
        }

        public void Drive(double amountKM)
        {
            var fuelNeeded = amountKM * this.FuelConspumtionPerKM;
            if (this.FuelAmout >= fuelNeeded)
            {
                this.FuelAmout -= fuelNeeded;
                this.TraveledDistance += amountKM;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }
    }
}
