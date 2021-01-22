using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        

        private string name;
        private Stats stats;
        
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.stats = stats;
        }

        public double SkillLevel => this.stats.SkillLevel();

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(Global.nameExeptionMessage);
                }
                this.name = value;
            }
        }

         
    }
}
