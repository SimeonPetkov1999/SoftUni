using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Dough
    {
       // private double doughCalories = 0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType,string bakingTechnique,double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight=weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                value = value.ToLower();
                if (value != "white" &&
                    value != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                value = value.ToLower();
                if (value != "crispy" &&
                    value != "chewy" &&
                    value != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var multipler = 1d;

            switch (FlourType)
            {
                case "white":
                    multipler *= 1.5;
                    break;
                case "wholegrain":
                    multipler *= 1.0;
                    break;
            }

            switch (BakingTechnique)
            {
                case "crispy":
                    multipler *= 0.9;
                    break;
                case "chewy":
                    multipler *= 1.1;
                    break;
                case "homemade":
                    multipler *= 1.0;
                    break;
            }

            return (2 * this.Weight) * multipler;
        }

    }


}
