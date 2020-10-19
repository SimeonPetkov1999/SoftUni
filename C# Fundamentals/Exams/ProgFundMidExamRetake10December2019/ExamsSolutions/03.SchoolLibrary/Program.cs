using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine()
                 .Split('&', StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            List<string> commands = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (commands[0] != "Done")
            {
                if (commands[0] == "Add Book")
                {
                    string book = commands[1].ToString();

                    if (!shelf.Contains(book))
                    {
                        shelf.Insert(0, book);
                    }
                }

                else if (commands[0] == "Take Book")
                {
                    string book = commands[1].ToString();
                    shelf.Remove(book);
                }

                else if (commands[0] == "Swap Books")
                {
                    string book1 = commands[1].ToString();
                    string book2 = commands[2].ToString();

                    if (shelf.Contains(book1) && shelf.Contains(book2))
                    {
                        int indexOfBook1 = shelf.IndexOf(book1);
                        int indexOfBook2 = shelf.IndexOf(book2);
                        string temp = shelf[indexOfBook1];
                        shelf[indexOfBook1] = shelf[indexOfBook2];
                        shelf[indexOfBook2] = temp;
                    }
                }

                else if (commands[0] == "Insert Book")
                {
                    string book = commands[1];
                    shelf.Add(book);
                }

                else if (commands[0] == "Check Book")
                {
                    int index = int.Parse(commands[1]);
                    if (index >= 0 && index <= shelf.Count - 1)
                    {
                        Console.WriteLine(shelf[index]);
                    }
                }

                commands = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            Console.WriteLine(string.Join(", ",shelf));
        }
    }
}
