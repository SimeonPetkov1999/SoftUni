using System;

namespace _06WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsInFirstSector = int.Parse(Console.ReadLine());
            int placesOddRow = int.Parse(Console.ReadLine());
            int allPlaces = 0;

            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                for (int rows = 1; rows <= rowsInFirstSector; rows++)
                {
                    if (rows % 2 != 0)
                    {
                        for (char odd = 'a'; odd < 'a' + placesOddRow; odd++)
                        {
                            Console.Write($"{sector}{rows}{odd}");
                            Console.WriteLine();
                            allPlaces++;
                        }
                    }

                    else
                    {
                        for (char even = 'a'; even <= 'a' + placesOddRow + 1; even++)
                        {
                            Console.Write($"{sector}{rows}{even}");
                            Console.WriteLine();
                            allPlaces++;
                        }

                    }

                }
                rowsInFirstSector++;
            }

            Console.WriteLine(allPlaces);
        }
    }
}
