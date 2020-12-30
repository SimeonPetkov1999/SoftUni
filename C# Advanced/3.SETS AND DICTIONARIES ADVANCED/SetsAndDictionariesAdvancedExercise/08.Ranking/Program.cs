using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var paswwordsForContests = new Dictionary<string, string>();
            addAllPaswords(paswwordsForContests);

            var allCandidates = new Dictionary<string, Dictionary<string, int>>();

            var commandArgs = Console.ReadLine()
                .Split("=>");
            while (commandArgs[0] != "end of submissions")
            {
                var contest = commandArgs[0];
                var password = commandArgs[1];
                var username = commandArgs[2];
                var points = int.Parse(commandArgs[3]);

                if (paswwordsForContests.ContainsKey(contest)
                    && paswwordsForContests[contest] == password)
                {
                    addCandidate(allCandidates, contest, username, points);
                }

                commandArgs = Console.ReadLine()
                .Split("=>");
            }

            var bestcandidate = string.Empty;
            int maxPoints = int.MinValue;
            foreach (var (key,value) in allCandidates)
            {
                int currentPoints = 0;
                foreach (var item in value)
                {
                    currentPoints += item.Value;
                }
                if (currentPoints>maxPoints)
                {
                    maxPoints = currentPoints;
                    bestcandidate = key;
                }
            }

            Console.WriteLine($"Best candidate is {bestcandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var item in allCandidates.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var (key,value) in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {key} -> {value}");
                }
            }
        }

        private static void addCandidate(Dictionary<string, Dictionary<string, int>> allCandidates, string contest, string username, int points)
        {
            if (!allCandidates.ContainsKey(username))
            {
                allCandidates.Add(username, new Dictionary<string, int>());
            }
            if (!allCandidates[username].ContainsKey(contest))
            {
                allCandidates[username].Add(contest, points);
            }
            if (allCandidates[username][contest] < points)
            {
                allCandidates[username][contest] = points;
            }
        }

        private static void addAllPaswords(Dictionary<string, string> paswwordsForContests)
        {
            var passwords = Console.ReadLine()
                            .Split(":", StringSplitOptions.RemoveEmptyEntries);
            while (passwords[0] != "end of contests")
            {
                var currentContest = passwords[0];
                var currentPassord = passwords[1];
                if (!paswwordsForContests.ContainsKey(currentContest))
                {
                    paswwordsForContests.Add(currentContest, currentPassord);
                }

                passwords = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
