using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInfo = Console.ReadLine().Split(' ');
                var doughInfo = Console.ReadLine().Split(' ');

                var pizzaName = pizzaInfo[1];
                var doughType = doughInfo[1];
                var doughTech = doughInfo[2];
                var doughWeight = double.Parse(doughInfo[3]);


                var dough = new Dough(doughType, doughTech, doughWeight);
                var pizza = new Pizza(pizzaName, dough);
                while (true)
                {
                    var toppingInfo = Console.ReadLine().Split(' ');
                    if (toppingInfo[0] == "END")
                    {
                        break;
                    }

                    var toppingType = toppingInfo[1];
                    var toppingWeight = double.Parse(toppingInfo[2]);

                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCallories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
