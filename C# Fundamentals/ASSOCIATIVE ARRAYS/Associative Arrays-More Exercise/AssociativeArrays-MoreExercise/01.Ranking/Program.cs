using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string[] commandContests = Console.ReadLine().Split(":");

            while (commandContests[0]!= "end of contests")
            {
                string contest = commandContests[0];
                string password = commandContests[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
                else
                {
                    contests[contest] = password;
                }

                commandContests = Console.ReadLine().Split(":");
            }

            Dictionary<string, Dictionary<string, int>> interns = new Dictionary<string, Dictionary<string, int>>();

            string[] command = Console.ReadLine().Split("=>");

            while (command[0] != "end of submissions")
            {
                string contest = command[0];
                string password = command[1];
                string username = command[2];
                int points = int.Parse(command[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!interns.ContainsKey(username))
                    {
                        interns.Add(username, new Dictionary<string, int>());
                        interns[username].Add(contest, points);
                    }

                    else if (!interns[username].ContainsKey(contest))
                    {
                        interns[username].Add(contest, points);
                    }

                    if (interns[username][contest]<points)
                    {
                        interns[username][contest] = points;
                    }             
                }           
                command = Console.ReadLine().Split("=>");
            }

            Dictionary<string, int> bestInterns = new Dictionary<string, int>();

            foreach (var intern in interns)
            {
                bestInterns[intern.Key] = intern.Value.Values.Sum();
            }

            string bestName = bestInterns.Keys.Max();
            int bestPoints = bestInterns.Values.Max();

            foreach (var intern in bestInterns)
            {
                if (intern.Value==bestPoints)
                {
                    Console.WriteLine($"Best candidate is {intern.Key} with total {intern.Value} points.");
                }
            }
          
            Console.WriteLine("Ranking: ");
            foreach (var name in interns.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{name.Key}");
                foreach (var contest in interns[name.Key].OrderByDescending(n=>n.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
         }
    }
}
