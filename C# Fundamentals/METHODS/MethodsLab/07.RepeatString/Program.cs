using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeatCount= int.Parse(Console.ReadLine());

            Console.WriteLine(Repeated(input, repeatCount));
        }

        static string Repeated(string input, int times)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                result.Append(input);
            }
            return result.ToString();
        }
    }
}
