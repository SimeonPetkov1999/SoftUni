using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = ReadData(n);

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            if (condition=="younger")
            {
                dictionary = dictionary.Where(x => x.Value <= age).ToDictionary(k => k.Key, v => v.Value);
            }
            else if (condition=="older")
            {
                dictionary = dictionary.Where(x => x.Value >= age).ToDictionary(k => k.Key, v => v.Value);              
            }
           

            foreach (var (keyName,valueAge) in dictionary)
            {
                if (format=="name")
                {
                    Console.WriteLine($"{keyName}");
                }
                else if(format=="age")
                {
                    Console.WriteLine($"{valueAge}");
                }
                else if (format=="name age")
                {
                    Console.WriteLine($"{keyName} - {valueAge}");
                }
            }


        }

        public static Dictionary<string,int> ReadData(int n)
        {
            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ");
                var name = input[0];
                var age = int.Parse(input[1]);
                dictionary.Add(name, age);
            }
            return  dictionary;
        }
    }
}
