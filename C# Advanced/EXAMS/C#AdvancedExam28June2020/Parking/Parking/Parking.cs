using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.data.Count;
        public void Add(Car car)
        {
            if (this.Capacity > this.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (!this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                return false;
            }
            this.data.RemoveAll(c => c.Manufacturer == manufacturer && c.Model == model);
            return true;
        }

        public Car GetLatestCar()
        {
            if (this.Count == 0)
            {
                return null;
            }
            return this.data.OrderByDescending(c => c.Year).First();
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (!this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                return null;
            }

            return this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd(); ;
        }
    }
}
