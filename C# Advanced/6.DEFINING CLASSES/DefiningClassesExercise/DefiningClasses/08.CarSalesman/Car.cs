using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = null;
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var engineDisplacement = this.Engine.Displacement == 0 ? "n/a" : $"{this.Engine.Displacement}";
            var engineEfficiency = this.Engine.Efficiency == null ? "n/a" : $"{this.Engine.Efficiency}";
            var carWeight = this.Weight == 0 ? "n/a" : $"{this.Weight}";
            var carColor = this.Color == null ? "n/a" : $"{this.Color}";

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            sb.AppendLine($"    Displacement: {engineDisplacement}");
            sb.AppendLine($"    Efficiency: {engineEfficiency}");
            sb.AppendLine($"  Weight: {carWeight}");
            sb.Append($"  Color: {carColor}");

            return sb.ToString();
        }
    }
}
