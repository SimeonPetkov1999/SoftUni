using System;

namespace _01Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfMovie = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (typeOfMovie)
            {
                case "Premiere":
                    price = (rows * colums) * 12.00;
                    break;
                case "Normal":
                    price = (rows * colums) * 7.50;
                    break;
                case "Discount":
                    price = (rows * colums) * 5.00;
                    break;
            }

            Console.WriteLine($"{price:f2} leva");
        }
    }
}
