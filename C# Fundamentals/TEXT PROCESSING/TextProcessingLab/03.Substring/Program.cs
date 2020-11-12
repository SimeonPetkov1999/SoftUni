using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine();
            string text = Console.ReadLine();

            int startIndex = 0;
            while (text.IndexOf(toRemove) != -1)
            {
                startIndex = text.IndexOf(toRemove);
                text = text.Remove(startIndex, toRemove.Length);
            }

            Console.WriteLine(text);

        }
    }
}
