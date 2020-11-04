using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                 .Split(new string[] { " = ", "#" }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            double water = double.Parse(Console.ReadLine());
            double effort = 0;
            double totalFire = 0;

            List<double> cells = new List<double>();

            for (int i = 0; i < input.Count; i += 2)
            {
                string typeOfFire = input[i].ToLower();
                double value = double.Parse(input[i + 1]);

                if (typeOfFire == "high" && (value >= 81 && value <= 125))
                {
                    addWater(ref water,value,ref effort,cells,ref totalFire);
                }

                else if (typeOfFire=="medium" && (value>=51 && value<=80))
                {
                    addWater(ref water, value, ref effort, cells, ref totalFire);
                }

                else if (typeOfFire=="low" && (value>=1&&value<=50))
                {
                    addWater(ref water, value, ref effort, cells, ref totalFire);
                }
            }
            Console.WriteLine("Cells:");
            foreach (var item in cells)
            {
                Console.WriteLine($" - {item}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
        static void addWater(ref double water, double value, ref double effort, List<double> cells,ref double totalFire) 
        {
            if ((water - value) >= 0)//?
            {
                water -= value;
                effort = effort + (value * 0.25);
                cells.Add(value);
                totalFire += value;
            }

        }
    }
}
