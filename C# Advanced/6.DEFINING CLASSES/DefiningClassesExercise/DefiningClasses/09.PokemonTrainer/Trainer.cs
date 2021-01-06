using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int NumberOfBages
        {
            get { return this.numberOfBadges; }
            set { this.numberOfBadges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons= value; }
        }

        public bool Any { get; internal set; }

        public Trainer(string name, int numberOfBages, List<Pokemon>pokemons)
        {
            this.Name = name;
            this.NumberOfBages = numberOfBages;
            this.Pokemons = pokemons;
        }
    }
}
