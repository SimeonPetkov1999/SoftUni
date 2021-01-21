using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {

                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.type = value.ToLower();
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var multiplier = 1d;
            switch (this.Type)
            {
                case "meat":
                    multiplier *= 1.2;
                    break;
                case "veggies":
                    multiplier *= 0.8;
                    break;
                case "cheese":
                    multiplier *= 1.1;
                    break;
                case "sauce":
                    multiplier *= 0.9;
                    break;
            }

            return (this.weight * 2) * multiplier;
        }
    }
}
