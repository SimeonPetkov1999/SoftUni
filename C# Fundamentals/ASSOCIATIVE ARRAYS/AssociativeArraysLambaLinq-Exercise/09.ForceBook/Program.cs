using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> book = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "Lumpawaroo")
                {
                    break;
                }
                string[] command;

                if (input.Contains("|"))
                {
                    command = input.Split(" | ");

                    string forceSide = command[0];
                    string forceUser = command[1];
                    bool IsContained = false;

                    if (!book.ContainsKey(forceSide))
                    {
                        foreach (var item in book.Values)
                        {
                            if (item.Contains(forceUser))
                            {
                                IsContained = true;
                                break;
                            }
                        }

                        if (!IsContained)
                        {
                            book.Add(forceSide, new List<string>());
                            book[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        foreach (var item in book.Values)
                        {
                            if (item.Contains(forceUser))
                            {
                                IsContained = true;
                                break;
                            }
                        }

                        if (!IsContained)
                        {
                            book[forceSide].Add(forceUser);
                        }
                    }

                }

                else if (input.Contains("->"))
                {
                    command = input.Split(" -> ");

                    string forceSide = command[1];
                    string forceUser = command[0];
                    bool IsContained = false;

                    if (!book.ContainsKey(forceSide))
                    {
                        foreach (var item in book.Values)
                        {
                            if (item.Contains(forceUser))
                            {
                                IsContained = true;
                                item.Remove(forceUser);
                                book[forceSide].Add(forceUser);
                                Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                                break;
                            }
                        }

                        if (!IsContained)
                        {
                            book.Add(forceSide, new List<string>());
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                            book[forceSide].Add(forceUser);
                        }

                    }
                    else
                    {
                        foreach (var item in book.Values)
                        {
                            if (item.Contains(forceUser))
                            {
                                IsContained = true;
                                item.Remove(forceUser);
                                book[forceSide].Add(forceUser);
                                Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                                break;
                            }
                        }

                        if (!IsContained)
                        {
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                            book[forceSide].Add(forceUser);
                        }
                    }

                }

                input = Console.ReadLine();
            }

            foreach (var side in book.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var person in side.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {person}");
                    }
                }
            }
        }
    }
}
