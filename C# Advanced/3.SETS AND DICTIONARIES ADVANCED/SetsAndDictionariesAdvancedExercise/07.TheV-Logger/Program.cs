using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var VLogger = new Dictionary<string, VLoggerData>();

            while (commandArgs[0] != "Statistics")
            {
                var command = commandArgs[1];
                var firstVlogger = commandArgs[0];
                var secondVlogger = commandArgs[2];
                if (command == "joined" && !VLogger.ContainsKey(firstVlogger))
                {
                    VLogger.Add(firstVlogger, new VLoggerData());
                }
                else if (command == "followed"
                    && firstVlogger != secondVlogger //Vlogger cannot follow himself
                    && VLogger.ContainsKey(firstVlogger)//If any of the given vlogernames does not exist 
                    && VLogger.ContainsKey(secondVlogger)//in you collection, ignore that command
                    && !VLogger[firstVlogger].following.Contains(secondVlogger))//Vlogger cannot follow someone he is already a follower of
                {
                    VLogger[firstVlogger].following.Add(secondVlogger);
                    VLogger[secondVlogger].followers.Add(firstVlogger);
                }
                commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<string> famousVloggersNames = addBestVloggersToList(VLogger);
            string bestVlogger = findBestVlogger(VLogger, famousVloggersNames);
            Print(VLogger, bestVlogger);
        }

        private static List<string> addBestVloggersToList(Dictionary<string, VLoggerData> VLogger)
        {
            List<string> famousVloggersNames = new List<string>();
            int mostFolowers = int.MinValue;
            foreach (var vlogger in VLogger)
            {
                if (vlogger.Value.followers.Count > mostFolowers)
                {
                    mostFolowers = vlogger.Value.followers.Count;
                    famousVloggersNames.Clear();
                    famousVloggersNames.Add(vlogger.Key);
                }
                else if (vlogger.Value.followers.Count == mostFolowers)
                {
                    famousVloggersNames.Add(vlogger.Key);
                }
            }

            return famousVloggersNames;
        }

        private static string findBestVlogger(Dictionary<string, VLoggerData> VLogger, List<string> famousVloggersNames)
        {
            string bestVlogger = string.Empty;
            if (famousVloggersNames.Count == 1)
            {
                bestVlogger = famousVloggersNames[0];
            }
            else
            {
                string vloggerFolowingLess = string.Empty;
                int following = int.MaxValue;
                foreach (var name in famousVloggersNames)
                {
                    if (VLogger[name].following.Count < following)
                    {
                        vloggerFolowingLess = name;
                        following = VLogger[name].following.Count;
                    }
                }
                bestVlogger = vloggerFolowingLess;
            }

            return bestVlogger;
        }

        public static void Print(Dictionary<string, VLoggerData> VLogger, string bestVlogger)
        {
            Console.WriteLine($"The V-Logger has a total of {VLogger.Count} vloggers in its logs.");
            Console.WriteLine($"1. {bestVlogger} : {VLogger[bestVlogger].followers.Count} followers, {VLogger[bestVlogger].following.Count} following");
            if (VLogger[bestVlogger].followers.Count > 0)
            {
                foreach (var item in VLogger[bestVlogger].followers.OrderBy(x => x))
                {
                    Console.WriteLine($"*  {item}");
                }
            }
            VLogger.Remove(bestVlogger);
            int num = 2;
            foreach (var (key, value) in VLogger.OrderByDescending(x => x.Value.followers.Count).ThenBy(x => x.Value.following.Count))
            {
                Console.WriteLine($"{num++}. {key} : {value.followers.Count} followers, {value.following.Count} following");
            }
        }

        public class VLoggerData
        {
            public VLoggerData()
            {
                followers = new List<string>();
                following = new List<string>();
            }
            public List<string> followers { get; set; }
            public List<string> following { get; set; }
        }
    }
}
