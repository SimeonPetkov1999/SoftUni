using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Band> bands = new Dictionary<string, Band>();

            string[] commandArgs = Console.ReadLine()
                .Split(new string[] { "; ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            while (commandArgs[0] != "start of concert")
            {
                string command = commandArgs[0];
                string bandName = commandArgs[1];
                if (command == "Add")
                {
                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, new Band());
                        bands[bandName].members = new List<string>();
                        for (int i = 2; i < commandArgs.Length; i++)
                        {
                            bands[bandName].members.Add(commandArgs[i]);
                        }
                    }
                    else
                    {
                        for (int i = 2; i < commandArgs.Length; i++)
                        {
                            if (!bands[bandName].members.Contains(commandArgs[i]))
                            {
                                bands[bandName].members.Add(commandArgs[i]);
                            }
                        }
                    }
                }
                else if (command == "Play")
                {
                    int time = int.Parse(commandArgs[2]);
                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, new Band());
                        bands[bandName].members = new List<string>();
                        bands[bandName].time = time;
                    }
                    else
                    {
                        if (bands[bandName].time == 0)
                        {
                            bands[bandName].time = time;
                        }
                        else
                        {
                            bands[bandName].time += time;
                        }
                    }
                }
                commandArgs = Console.ReadLine()
             .Split(new string[] { "; ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            }
            string outputBandName = Console.ReadLine();
            int totalTime = bands.Select(n => n.Value.time)
                             .ToList()
                             .Sum();
            Console.WriteLine($"Total time: {totalTime}");
            foreach (var item in bands.OrderByDescending(n => n.Value.time).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.time}");
            }

            Console.WriteLine(outputBandName);
            foreach (var item in bands[outputBandName].members)
            {
                Console.WriteLine($"=> {item}");
            }
         }
        public class Band
        {

            public int time { get; set; }
            public List<string> members { get; set; }
        }
    }
}
