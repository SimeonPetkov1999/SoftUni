using System;

namespace _01SeriesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfSeries = Console.ReadLine();
            int numberOFSeasons = int.Parse(Console.ReadLine());
            int numberOFEpisodes = int.Parse(Console.ReadLine());
            int lenghtOfEpisodeNoAdds = int.Parse(Console.ReadLine());

            double lenghtOfAdd = lenghtOfEpisodeNoAdds * 0.20;
            double lenghtOfEpisodeWithAdd = lenghtOfEpisodeNoAdds + lenghtOfAdd;
            double additionalTime = numberOFSeasons * 10;
            double WatchTime = Math.Floor((lenghtOfEpisodeWithAdd * numberOFEpisodes * numberOFSeasons) + additionalTime);


            Console.WriteLine($"Total time needed to watch the {nameOfSeries} series is {WatchTime} minutes.");

        }
    }
}
