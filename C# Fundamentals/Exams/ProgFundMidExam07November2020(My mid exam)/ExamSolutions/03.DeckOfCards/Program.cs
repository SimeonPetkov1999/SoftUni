using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];

                if (command=="Add")
                {
                    string cardName = commandArgs[1];
                    if (cards.Contains(cardName))
                    {
                        Console.WriteLine($"Card is already bought");
                    }
                    else
                    {
                        Console.WriteLine($"Card successfully bought");
                        cards.Add(cardName);
                    }
                }

                else if (command=="Remove")
                {
                    string cardName = commandArgs[1];
                    if (cards.Contains(cardName))
                    {
                        Console.WriteLine("Card successfully sold");
                        cards.Remove(cardName);//?
                    }
                    else 
                    {
                        Console.WriteLine("Card not found");  
                    }
                }
                else if (command== "Remove At")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (index>=0 && index<=cards.Count-1)
                    {
                        Console.WriteLine("Card successfully sold");
                        cards.RemoveAt(index);
                    }

                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }

                else if (command=="Insert")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (index<0 || index>=cards.Count)
                    {
                        Console.WriteLine("Index out of range");
                        continue;
                    }
                    string cardName = commandArgs[2];
                    if (!cards.Contains(cardName))
                    {
                        cards.Insert(index, cardName);
                        Console.WriteLine("Card successfully bought");
                    }
                    else
                    {
                        Console.WriteLine("Card is already bought");
                    }
                }                    
            }
            Console.WriteLine(string.Join(", ",cards));
        }
    }
}
