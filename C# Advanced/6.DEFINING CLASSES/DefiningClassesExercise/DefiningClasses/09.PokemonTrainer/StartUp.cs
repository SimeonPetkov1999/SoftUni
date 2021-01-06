using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // PROBLEM SOLVED USING List<Trainer>

            var traniersWithPokemons = new List<Trainer>();
            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Tournament")
                {
                    break;
                }

                var trainerName = command[0];
                var pokemonName = command[1];
                var pokemonElement = command[2];
                var pokemonHealth = int.Parse(command[3]);

                if (!traniersWithPokemons.Any(t => t.Name == trainerName))
                {
                    traniersWithPokemons.Add(new Trainer(trainerName, 0, new List<Pokemon>()));
                }
                var currentTrainer = traniersWithPokemons.FirstOrDefault(t => t.Name == trainerName);
                currentTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            while (true)
            {
                var type = Console.ReadLine();
                if (type == "End")
                {
                    break;
                }

                var trainersCount = traniersWithPokemons.Count;
                for (int i = 0; i < trainersCount; i++)
                {
                    var currentTrainer = traniersWithPokemons[i];

                    if (currentTrainer.Pokemons.Any(p => p.Element == type))
                    {
                        currentTrainer.NumberOfBages++;
                    }
                    else
                    {
                        currentTrainer.Pokemons.ForEach(p => p.Health -= 10);
                        for (int j = 0; j < currentTrainer.Pokemons.Count; j++)
                        {
                            if (currentTrainer.Pokemons[j].Health <= 0)
                            {
                                currentTrainer.Pokemons.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
            }
            foreach (var trainer in traniersWithPokemons.OrderByDescending(n=>n.NumberOfBages))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBages} {trainer.Pokemons.Count}");
            }



            // PROBLEM SOLVED USING Dictionary<string, Trainer>

            //var traniersWithPokemons = new Dictionary<string, Trainer>();

            //while (true)
            //{
            //    var command = Console.ReadLine()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    if (command[0] == "Tournament")
            //    {
            //        break;
            //    }

            //    var trainerName = command[0];
            //    var pokemonName = command[1];
            //    var pokemonElement = command[2];
            //    var pokemonHealth = int.Parse(command[3]);

            //    if (!traniersWithPokemons.ContainsKey(trainerName))
            //    {
            //        traniersWithPokemons.Add(trainerName, new Trainer(trainerName, 0, new List<Pokemon>()));
            //    }
            //    traniersWithPokemons[trainerName]
            //        .Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            //}

            //while (true)
            //{
            //    var type = Console.ReadLine();
            //    if (type == "End")
            //    {
            //        break;
            //    }
            //    foreach (var trainer in traniersWithPokemons)
            //    {
            //        if (trainer.Value.Pokemons.Any(p => p.Element == type))
            //        {
            //            trainer.Value.NumberOfBages++;
            //        }
            //        else
            //        {
            //            foreach (var pokemon in trainer.Value.Pokemons)
            //            {
            //                pokemon.Health -= 10;
            //            }
            //            for (int i = 0; i < traniersWithPokemons[trainer.Key].Pokemons.Count; i++)
            //            {
            //                if (traniersWithPokemons[trainer.Key].Pokemons[i].Health<=0)
            //                {
            //                    traniersWithPokemons[trainer.Key].Pokemons.RemoveAt(i);
            //                    i--;
            //                }
            //            }
            //        }
            //    }
            //}

            //foreach (var trainer in traniersWithPokemons
            //    .OrderByDescending(t => t.Value.NumberOfBages))
            //{
            //    Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBages} {trainer.Value.Pokemons.Count}");
            //}
        }
    }
}
