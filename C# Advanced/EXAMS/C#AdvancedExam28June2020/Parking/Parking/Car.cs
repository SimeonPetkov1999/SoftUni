using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        public Car(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public override string ToString()
        {
            return $"{this.Manufacturer} {this.Model} ({this.Year})";
        }
    }
}
