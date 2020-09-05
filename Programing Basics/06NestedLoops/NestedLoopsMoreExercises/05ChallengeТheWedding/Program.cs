using System;
using System.Data;

namespace _05ChallengeТheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBoys = int.Parse(Console.ReadLine());
            int numberOfGirls = int.Parse(Console.ReadLine());
            int numberOfTables = int.Parse(Console.ReadLine());
            int table = 1;

            for (int boy = 1; boy <= numberOfBoys; boy++)
            {
                for (int girl = 1; girl <= numberOfGirls; girl++)
                {
                   
                    Console.Write($"({boy} <-> {girl}) ");
                    table++;
                    if (table>numberOfTables)
                    {
                        Environment.Exit(0);
                    }

                }
            }



        }
    }
}
