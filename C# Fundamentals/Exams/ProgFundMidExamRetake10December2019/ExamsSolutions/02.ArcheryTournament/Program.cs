using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine()
                 .Split('|', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            List<string> command = Console.ReadLine().Split(' ', '@').ToList();
            int points = 0;

            while (command[0] != "Game")
            {
                if (command[0] == "Shoot" && command[1] == "Left")
                {
                    int startIndex = int.Parse(command[2]);
                    if (IsInRange(field, startIndex))
                    {
                        int lenght = int.Parse(command[3]);
                        int shotIndex = MoveLeft(field, startIndex, lenght);
                        Decrease(field, ref points, shotIndex);
                    }
                }

                else if (command[0] == "Shoot" && command[1] == "Right")
                {
                    int startIndex = int.Parse(command[2]);
                    if (IsInRange(field, startIndex))
                    {
                        int lenght = int.Parse(command[3]);
                        int shotIndex = MoveRight(field, startIndex, lenght);
                        Decrease(field, ref points, shotIndex);
                    }
                }

                else if (command[0] == "Reverse")
                {
                    field.Reverse();
                }
                command = Console.ReadLine().Split(' ', '@').ToList();
            }

            Console.WriteLine(string.Join(" - ", field));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }

        static bool IsInRange(List<int> field, int index)
        {
            if (index >= 0 && index <= field.Count - 1)
            {
                return true;
            }
            return false;
        }
        static int MoveLeft(List<int> field, int startIndex, int lenght)
        {
            int shotIndex = startIndex;
            int step = 0;
            while (step < lenght)
            {
                if (shotIndex - 1 < 0)
                {
                    shotIndex = field.Count - 1;
                    step++;
                }
                else
                {
                    shotIndex--;
                    step++;
                }
            }
            return shotIndex;
        }

        static int MoveRight(List<int> field, int startIndex, int lenght) 
        {
            int shotIndex = startIndex;
            int step = 0;
            while (step < lenght)
            {
                if (shotIndex + 1 > field.Count - 1)
                {
                    shotIndex = 0;
                    step++;
                }
                else
                {
                    shotIndex++;
                    step++;
                }
            }
            return shotIndex;
        }

        static void Decrease(List<int> field, ref int point, int shotIndex) 
        {
            if (field[shotIndex] < 5)
            {
                point += field[shotIndex];
                field[shotIndex] = 0;
            }
            else
            {
                field[shotIndex] = field[shotIndex] - 5;
                point += 5;
            }
        }
    }
}
