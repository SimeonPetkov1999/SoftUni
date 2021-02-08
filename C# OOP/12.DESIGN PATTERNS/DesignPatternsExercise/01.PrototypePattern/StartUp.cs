using System;

namespace _01.PrototypePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["Princess"] = new Sandwich("Wheat", "Minced Meat", "", "Tomato");
            sandwichMenu["Cheese"] = new Sandwich("Wheat", "", "CH", "Tomato");

            Sandwich sandwich1 = (Sandwich)sandwichMenu["BLT"].Clone();
            Sandwich sandwich2 = sandwichMenu["Princess"].Clone() as Sandwich;


            
        }
    }
}
