using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> judge = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> standings = new Dictionary<string, int>();


            string[] command = Console.ReadLine().Split(" -> ");

            while (command[0] != "no more time")
            {
                string username = command[0];
                string contest = command[1];
                int points = int.Parse(command[2]);

                if (!judge.ContainsKey(contest))
                {
                    judge.Add(contest, new Dictionary<string, int>());
                    judge[contest].Add(username, points);
                }
                else if (!judge[contest].ContainsKey(username))
                {
                    judge[contest].Add(username, points);
                }
                else if (judge[contest][username] < points)
                {
                    judge[contest][username] = points;
                    standings[username] = points;
                    command = Console.ReadLine().Split(" -> ");
                    continue;
                }

                if (!standings.ContainsKey(username))
                {
                    standings.Add(username, points);
                }
                else
                {
                    standings[username] += points;
                }

                command = Console.ReadLine().Split(" -> ");
            }


            foreach (var contest in judge)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int i = 1;
                foreach (var participant in contest.Value.OrderByDescending(n => n.Value)
                    .ThenBy(n => n.Key)
                    .ThenBy(n => n))
                {
                    Console.WriteLine($"{i++}. {participant.Key} <::> {participant.Value}");
                }

            }

            int index = 1;
            Console.WriteLine("Individual standings:");
            foreach (var participant in standings.OrderByDescending(n => n.Value)
                .ThenBy(n => n.Key)
                .ThenBy(n => n))
            {
                Console.WriteLine($"{index++}. {participant.Key} -> {participant.Value}");
            }

        }
    }
}
