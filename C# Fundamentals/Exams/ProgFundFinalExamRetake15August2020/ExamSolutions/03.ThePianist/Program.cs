using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Composer> composers = new Dictionary<string, Composer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string piece = input[0];
                string composer = input[1];
                string key = input[2];
                composers.Add(piece, new Composer(composer, key));//?
            }

            string[] commandArgs = Console.ReadLine().Split("|");

            while (commandArgs[0]!="Stop")
            {
                string command = commandArgs[0];
                string piece = commandArgs[1];
                if (command=="Add")
                {
                    string composer = commandArgs[2];
                    string key = commandArgs[3];
                    if (!composers.ContainsKey(piece))
                    {
                        composers.Add(piece, new Composer(composer, key));
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (command=="Remove")
                {
                    if (composers.ContainsKey(piece))
                    {
                        composers.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if(command=="ChangeKey")
                {
                    string newKey = commandArgs[2];
                    if (composers.ContainsKey(piece))
                    {
                        composers[piece].key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                commandArgs = Console.ReadLine().Split("|");
            }

            foreach (var item in composers.OrderBy(n=>n.Key).ThenBy(n=>n.Value.composer))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.composer}, Key: {item.Value.key}");
            }
        }

        public class Composer
        {
            public Composer(string composer, string key)
            {
                this.composer = composer;
                this.key = key;
            }
            public string composer { get; set; }
            public string key { get; set; }
        }
    }
}
