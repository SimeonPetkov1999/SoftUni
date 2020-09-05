using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()) * 0.01;

            double volume = length * width * height;
            double liters = volume * 0.001;
            double FinalLiters = liters * (1 - percentage);

            Console.WriteLine(FinalLiters);

        }
    }
}
