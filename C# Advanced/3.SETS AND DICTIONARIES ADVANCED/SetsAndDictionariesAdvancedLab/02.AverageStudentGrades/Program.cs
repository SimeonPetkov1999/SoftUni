using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, new List<decimal>());
                    dictionary[name].Add(grade);
                }
                else 
                {
                    dictionary[name].Add(grade);
                }
            }

            foreach (var (keyName, value) in dictionary)
            {
                var average = value.Average();
                var grades = string.Join(" ", value.Select(x=>x.ToString("f2")));
                Console.WriteLine($"{keyName} -> {grades} (avg: {average:f2})");
            }
        }
    }
}
