using System;
using System.Linq;

namespace _04.Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var stones = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
