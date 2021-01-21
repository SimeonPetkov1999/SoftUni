using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const string nameExeptionMessage = "A name should not be empty.";
        private const string statsExeptionMessage = "{0} should be between 0 and 100.";


        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance,int sprint,int dribble,int passing,int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(nameExeptionMessage);
                }
                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint 
        {
            get => this.sprint;
            private set 
            {
                ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble 
        {
            get => this.dribble;
            private set 
            {
                ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing 
        {
            get => this.passing;
            private set 
            {
                ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting 
        {
            get => this.shooting;
            private set 
            {
                ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double SkillLevel() 
        {
            double overal =(this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
            return overal;
        }

        private void ValidateStat(int value, string stat)
        {
            if (value < 0 || value > 100)
            {
                throw new InvalidOperationException(String.Format(statsExeptionMessage, stat));
            }
        }
    }
}
