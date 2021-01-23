using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : ICar, IElectricCar
    {
        public Tesla(string model,string color,int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries")
                .AppendLine(this.Start())
                .Append(this.Stop());

            return sb.ToString();
        }
    }
}
