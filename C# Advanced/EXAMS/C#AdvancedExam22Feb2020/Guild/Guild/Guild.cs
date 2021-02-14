using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => this.roster.Count; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var removed = this.roster.RemoveAll(p => p.Name == name);
            if (removed == 0)
            {
                return false;
            }
            return true;
        }

        public void PromotePlayer(string name)
        {
            this.roster.First(p => p.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            this.roster.First(p => p.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var removed = this.roster.Where(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);
            return removed;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
