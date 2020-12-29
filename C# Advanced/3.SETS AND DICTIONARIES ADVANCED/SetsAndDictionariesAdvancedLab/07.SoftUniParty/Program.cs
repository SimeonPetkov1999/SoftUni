using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipNumbers = new HashSet<string>();
            var normalNumbers = new HashSet<string>();

            var number = Console.ReadLine();
            while (number != "PARTY")
            {
                if (char.IsDigit(number[0]))
                {
                    vipNumbers.Add(number);
                }
                else
                {
                    normalNumbers.Add(number);
                }
                number = Console.ReadLine();
            }

            number = Console.ReadLine();
            while (number!="END")
            {
                if (char.IsDigit(number[0]))
                {
                    vipNumbers.Remove(number);
                }
                else
                {
                    normalNumbers.Remove(number);
                }
                number = Console.ReadLine();
            }

            Console.WriteLine(vipNumbers.Count + normalNumbers.Count);
            foreach (var item in vipNumbers)
            {
                Console.WriteLine(item);
            }
            foreach (var item in normalNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
