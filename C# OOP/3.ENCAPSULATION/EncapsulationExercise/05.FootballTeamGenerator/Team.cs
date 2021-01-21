using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public void AddPlayer(Player player) 
        {
            this.players.Add(player);  
        }

        public void RemovePlayer(string playerName) 
        {
            if (!this.players.Any(p=>p.Name==playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }
            var toRemove = players.FirstOrDefault(p => p.Name == playerName);
            this.players.Remove(toRemove);
        }

        public int Rating() 
        {
            var rating = 0.0;
            foreach (var player in players)
            {
                rating += player.SkillLevel();
            }
            if (this.players.Count>0)
            {
                rating /= players.Count;
            }
            else
            {
                rating = 0;
            }
            return (int)Math.Round(rating);
        }

    }
}
