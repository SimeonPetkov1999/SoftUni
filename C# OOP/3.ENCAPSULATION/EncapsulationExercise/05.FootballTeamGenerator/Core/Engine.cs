using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            while (true)
            {
                var commandArgs = Console.ReadLine().Split(';');
                var command = commandArgs[0];
                if (command == "END")
                {
                    break;
                }
                try
                {
                    var teamName = commandArgs[1];
                    if (command == "Team")
                    {
                        this.teams.Add(new Team(commandArgs[1]));
                    }
                    else if (command == "Add")
                    {
                        this.ValidateTeamExist(teams, teamName);
                        this.AddPlayer(teams, commandArgs, teamName);
                    }
                    else if (command == "Remove")
                    {
                       this.ValidateTeamExist(teams, teamName);
                        this.RemovePlayer(teams, commandArgs);
                    }
                    else if (command == "Rating")
                    {
                        this.ValidateTeamExist(teams, teamName);
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        Console.WriteLine($"{team.Name} - {team.Rating()}");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        private void ValidateTeamExist(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new InvalidOperationException(String.Format(Global.validateTeamExeptionMessage, teamName));
            }
        }

        private void RemovePlayer(List<Team> teams, string[] commandArgs)
        {
            var teamName = commandArgs[1];
            var playerName = commandArgs[2];
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            team.RemovePlayer(playerName);
        }

        private void AddPlayer(List<Team> teams, string[] commandArgs, string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            var playerName = commandArgs[2];
            Stats stats = GetStats(commandArgs);
            Player player = new Player(playerName, stats);
            team.AddPlayer(player);
        }

        private Stats GetStats(string[] commandArgs)
        {
            var endurance = int.Parse(commandArgs[3]);
            var sprint = int.Parse(commandArgs[4]);
            var dribble = int.Parse(commandArgs[5]);
            var passing = int.Parse(commandArgs[6]);
            var shooting = int.Parse(commandArgs[7]);
            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;
        }
    }
}
