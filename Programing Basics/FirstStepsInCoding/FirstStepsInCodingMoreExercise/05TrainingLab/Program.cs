using System;

namespace _05TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            lenght = lenght * 100;
            width = width * 100 - 100;

            double rows = Math.Floor(width / 70);
            double places = Math.Floor(lenght / 120);

            double numberOfPlaces = rows * places - 3;

            Console.WriteLine(numberOfPlaces);

        }
    }
}
