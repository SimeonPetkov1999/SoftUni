using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        private double overallPerformance;
        private decimal computerPrice;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            //this.Manufacturer = manufacturer;
            //this.Model = model;
            this.computerPrice = price;
            this.overallPerformance = overallPerformance;

            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        //public int Id { get; private set; }//Check if needed to verify

        // public string Manufacturer { get; private set; }

        // public string Model { get; private set; }


        public override decimal Price => this.computerPrice + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);//?



        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return this.overallPerformance;
                }
                return this.overallPerformance + (this.components.Average(x => x.OverallPerformance));
                //?
            }
            //private set { this.overallPerformance = value; }
        }

        public void AddComponent(IComponent component)
        {
            var comp = this.components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);
            if (comp != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, comp.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var per = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);
            if (per != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, per.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (this.components.Count == 0 || component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (this.peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");

            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            var average = this.peripherals.Count == 0 ? 0 : this.peripherals.Average(x => x.OverallPerformance);
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({average:f2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
