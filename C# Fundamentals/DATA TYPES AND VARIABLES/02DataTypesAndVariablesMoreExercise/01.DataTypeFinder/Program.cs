using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool inputInt = int.TryParse(input, out _);
                bool inputDouble = double.TryParse(input, out _);
                bool inputChar = char.TryParse(input, out _);
                bool inputCBool = bool.TryParse(input, out _);

                if (inputInt)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (inputDouble)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (inputChar)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (inputCBool)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
