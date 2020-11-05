using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] != "End")
            {
                string companyName = input[0];
                string ID = input[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                    companies[companyName].Add(ID);
                }

                else if (!companies[companyName].Contains(ID))
                {
                    companies[companyName].Add(ID);
                }
                input = Console.ReadLine().Split(" -> ");
            }

            companies = companies.OrderBy(x => x.Key).ToDictionary(n => n.Key, m => m.Value);

            foreach (var commpany in companies)
            {
                Console.WriteLine($"{commpany.Key}");
                foreach (var user in commpany.Value)
                {
                    Console.WriteLine($"-- {user}");
                }

            }
        }
    }
}
