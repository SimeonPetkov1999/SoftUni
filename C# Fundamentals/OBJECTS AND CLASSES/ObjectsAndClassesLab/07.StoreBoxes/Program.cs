using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] data = Console.ReadLine().Split();

            List<Box> fullData = new List<Box>();

            while (data[0] != "end")
            {
                string serialNumber = data[0];
                string itemName = data[1];
                double itemQuantity = double.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);

                Box currentBox = new Box();
                currentBox.Item = new Item();

                currentBox.SerialNumber = serialNumber;
                currentBox.Item.Name = itemName;
                currentBox.Quantity = itemQuantity;
                currentBox.Item.Price = itemPrice;

                fullData.Add(currentBox);

                data = Console.ReadLine().Split();
            }
            foreach (var box in fullData)
            {
                box.PriceForBox = box.Item.Price * box.Quantity;
            }

            fullData = fullData.OrderBy(x => x.PriceForBox).ToList();
            fullData.Reverse();
            foreach (var box in fullData)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }

        public class Item
        {
            public string Name;
            public double Price;
        }
        public class Box
        {
            public Box()
            {
                Item = new Item();
            }

            public string SerialNumber;
            public Item Item;
            public double Quantity;
            public double PriceForBox;
        }


    }
}
