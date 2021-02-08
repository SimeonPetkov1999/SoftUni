using System;

namespace _02.CompositePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Note 10", 1999);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var box = new CompositeGift("Box", 0);
            var truck = new SingleGift("Truck", 15);
            var car = new SingleGift("Car", 10);

            box.Add(truck);
            box.Add(car);

            var childBox = new CompositeGift("ChildBox", 0);
            var toy = new SingleGift("Toy", 50);
            var soldier = new SingleGift("Soldier", 55);
            childBox.Add(soldier);
            childBox.Add(toy);
            box.Add(childBox);
            Console.WriteLine($"Total price of this box: {box.CalculateTotalPrice()}");
        }
    }
}
