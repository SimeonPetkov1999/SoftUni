using System;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();


            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }
                sb.Append(input);

                int keyIndex = 0;
                for (int i = 0; i < sb.Length; i++)
                {
                    if (keyIndex>=keys.Length)
                    {
                        keyIndex = 0;
                    }
                    sb[i] -= (char)keys[keyIndex];
                    keyIndex++;
                }

                string decripted = sb.ToString();

                int lenghtType = decripted.LastIndexOf('&') - decripted.IndexOf('&');
                int lenhtCoordinates = decripted.IndexOf('>') - decripted.IndexOf('<');
                string type = decripted.Substring(decripted.IndexOf('&')+1, lenghtType-1);
                string coordinates = decripted.Substring(decripted.IndexOf('<') + 1, lenhtCoordinates - 1);

                Console.WriteLine($"Found {type} at {coordinates}");

                sb.Clear();
            }
        }
    }
}
