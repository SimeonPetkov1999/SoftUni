using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] inputForCreatingTeams = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);

                string creatorName = inputForCreatingTeams[0];
                string teamName = inputForCreatingTeams[1];

                Team currentTeam = new Team();
                currentTeam.Creator = creatorName;
                currentTeam.Name = teamName;

                bool isTeamNameExist = teams.Select(n => n.Name).Contains(teamName);
                bool isCreatorOnlyOne = teams.Select(n => n.Creator).Contains(creatorName);

                if (!isTeamNameExist)
                {
                    if (!isCreatorOnlyOne)
                    {
                        teams.Add(currentTeam);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }


            string[] input = Console.ReadLine().Split("->");
            while (input[0] != "end of assignment")
            {
                string playerName = input[0];
                string teamName = input[1];

                bool isCreatorExist = teams.Select(n => n.Creator).Contains(playerName);
                bool isMemberExist = teams.Select(n => n.Members).Any(n => n.Contains(playerName));

                if (!teams.Select(n => n.Name).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isCreatorExist || isMemberExist)
                {
                    Console.WriteLine($"Member {playerName} cannot join team {teamName}!");
                }
                else
                {
                    int index = teams.FindIndex(n => n.Name == teamName);
                    teams[index].Members.Add(playerName);                   
                }
                input = Console.ReadLine().Split("->");
            }

            Team[] teamsToDisband = teams.OrderBy(x => x.Name)
                                         .Where(x => x.Members.Count == 0)
                                         .ToArray();
            Team[] fullTeam = teams.OrderByDescending(x => x.Members.Count)
                                   .ThenBy(x => x.Name)
                                   .Where(x => x.Members.Count > 0)
                                   .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in fullTeam)
            {
                sb.AppendLine($"{team.Name}");
                sb.AppendLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x=>x))
                {
                    sb.AppendLine($"-- {member}");
                }               
            }

            sb.AppendLine("Teams to disband:");
            foreach (Team item in teamsToDisband)
            {
                sb.AppendLine(item.Name);
            }

            Console.WriteLine(sb.ToString());

        }

        class Team
        {
            public Team()
            {
                Members = new List<string>();
            }
            public string Name { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }
        }
    }
}
