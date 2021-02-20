using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers; 
        public Race(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get => this.racers.Count; }

        public void Add(Racer Racer) 
        {
            if (this.racers.Count<this.Capacity)
            {
                this.racers.Add(Racer);
            }
        }

        public bool Remove(string name) 
        {
            var toRemove = this.racers.FirstOrDefault(r => r.Name == name);
            return this.racers.Remove(toRemove);
        }

        public Racer GetOldestRacer() 
        {
            return this.racers.OrderByDescending(r => r.Age).First();
        }

        public Racer GetRacer(string name) 
        {
            return this.racers.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer() 
        {
            return this.racers.OrderByDescending(r => r.Car.Speed).First();
        }

        public string Report() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in this.racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
