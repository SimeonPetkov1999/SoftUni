using System;
using System.Text;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            

            StringBuilder chars = new StringBuilder();
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            for (char i = (char)((char)Math.Min(first,second)+1); i <= (char)Math.Max(first, second)-1; i++)
            {
                chars.Append(i);
            }

            string mychars = chars.ToString();
            int sum = 0;
            string input = Console.ReadLine();

            foreach (var item in input)
            {
                if (mychars.Contains(item))
                {
                    sum += item;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
