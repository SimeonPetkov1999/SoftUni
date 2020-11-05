using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            students = students.Where(x => x.Value.Average() >= 4.5).ToDictionary(n => n.Key, m => m.Value);

            foreach (var item in students.OrderByDescending(x=>x.Value.Average()))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");             
            }

        }
    }
}
