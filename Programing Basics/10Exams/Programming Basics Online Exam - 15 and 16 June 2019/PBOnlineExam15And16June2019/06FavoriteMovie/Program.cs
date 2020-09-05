using System;

namespace _06FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentsPoints = 0;
            int currentFinalPoints = 0;
            int maxPoints = 0;
            string maxPointMovie = null;
            int moviesNum = 0;

            while (true)
            {
                string movie = Console.ReadLine();
                moviesNum++;
                int lenght = movie.Length;
                if (movie == "STOP")
                {
                    Console.WriteLine($"The best movie for you is {maxPointMovie} with {maxPoints} ASCII sum.");
                    Environment.Exit(0);
                }

                for (int i = 0; i < lenght; i++)
                {
                    // char currentD = movie[i];
                    char currentDigit = movie[i];
                    if (currentDigit >= 65 && currentDigit <= 90)
                    {
                        currentsPoints = (currentDigit - lenght);
                        currentFinalPoints = currentFinalPoints + currentsPoints;
                    }

                    else if (currentDigit >= 97 && currentDigit <= 122)
                    {
                        currentsPoints = (currentDigit - lenght * 2);
                        currentFinalPoints = currentFinalPoints + currentsPoints;
                    }
                    else if (currentDigit < 97 || currentDigit > 122)
                    {
                        currentFinalPoints = currentFinalPoints + currentDigit;
                    }
                }

                if (currentFinalPoints > maxPoints)
                {
                    maxPoints = currentFinalPoints;
                    maxPointMovie = movie;
                }
                currentFinalPoints = 0;
                if (moviesNum == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    Console.WriteLine($"The best movie for you is {maxPointMovie} with {maxPoints} ASCII sum.");
                    Environment.Exit(0);
                }
            }
        }
    }
}
