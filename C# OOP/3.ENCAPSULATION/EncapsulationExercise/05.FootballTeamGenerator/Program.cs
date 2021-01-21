using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            while (true)
            {
                var commandArgs = Console.ReadLine()
                    .Split(';');
                if (commandArgs[0]=="END")
                {
                    break;
                }

                if (commandArgs[0] == "Team")
                {
                    teams.Add(new Team(commandArgs[1]));
                }
                else if (commandArgs[0] == "Add")
                {
                    var teamName = commandArgs[1];
                    if (teams.Any(t => t.Name == teamName))
                    {
                        try
                        {
                            AddPlayer(teams, commandArgs, teamName);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    try
                    {
                        RemovePlayer(teams, commandArgs);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }               
                }
                else if (commandArgs[0]=="Rating")
                {
                    var teamName = commandArgs[1];
                    if (teams.Any(t=>t.Name==teamName))
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        Console.WriteLine($"{team.Name} - {team.Rating()}");
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
            }
        }

        private static void RemovePlayer(List<Team> teams, string[] commandArgs)
        {
            var teamName = commandArgs[1];
            var playerName = commandArgs[2];
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private static void AddPlayer(List<Team> teams, string[] commandArgs, string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            var playerName = commandArgs[2];
            var endurance = int.Parse(commandArgs[3]);
            var sprint = int.Parse(commandArgs[4]);
            var dribble = int.Parse(commandArgs[5]);
            var passing = int.Parse(commandArgs[6]);
            var shooting = int.Parse(commandArgs[7]);


            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }
    }
}
