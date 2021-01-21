using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length>15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            } 
        }

        public void AddTopping(Topping topping) 
        {
            if (this.toppings.Count+1>10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public double GetCallories() 
        {
            var calories = this.dough.GetCalories();

            foreach (var topping in toppings)
            {
                calories += topping.GetCalories();
            }

            return calories;
        }
    }
}
