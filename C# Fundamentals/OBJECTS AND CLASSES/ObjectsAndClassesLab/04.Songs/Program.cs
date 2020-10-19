using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                List<string> currentSongInfo = Console.ReadLine().Split('_').ToList();

                Song song = new Song();
                song.TypeList = currentSongInfo[0];
                song.Name = currentSongInfo[1];
                song.Time = currentSongInfo[2];
                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                for (int i = 0; i < songs.Count; i++)
                {
                    if (typeList == songs[i].TypeList)
                    {
                        Console.WriteLine(songs[i].Name);
                    }
                }
            }
        }
        public class Song
        {
            public string TypeList;
            public string Name;
            public string Time;
        }
    }
}
