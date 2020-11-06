using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExam_esults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submisions = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split(new string[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "exam")
            {
                if (input.Length == 3)
                {
                    string username = input[0];
                    string language = input[1];
                    int points = int.Parse(input[2]);

                    if (!results.ContainsKey(username))
                    {
                        results.Add(username, points);
                    }
                    else if (results[username] < points)
                    {
                        results[username] = points;
                    }

                    if (!submisions.ContainsKey(language))
                    {
                        submisions.Add(language, 1);
                    }
                    else
                    {
                        submisions[language]++;
                    }
                }
                else if (input.Length == 2)
                {
                    string username = input[0];
                    results.Remove(username);
                }
                input = Console.ReadLine()
                      .Split(new string[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Results:");
            foreach (var item in results.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var item in submisions.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
