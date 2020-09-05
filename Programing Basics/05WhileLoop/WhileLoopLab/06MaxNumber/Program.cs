using System;

namespace _06MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double num;
            double max = double.MinValue;

            while (input!="Stop")
            {
                num = double.Parse(input);
                if (num>max)
                {
                    max = num;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(max);


        }
    }
}
