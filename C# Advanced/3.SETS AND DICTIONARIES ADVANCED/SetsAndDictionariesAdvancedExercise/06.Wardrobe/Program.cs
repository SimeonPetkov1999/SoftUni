using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var color = currentLine[0];
                var clothes = currentLine[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    var currentItem = clothes[j];
                    if (!wardrobe[color].ContainsKey(currentItem))
                    {
                        wardrobe[color].Add(currentItem, 0);
                    }
                    wardrobe[color][currentItem]++;

                }
            }

            var toFind = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var colorToFind = toFind[0];
            var clothToFind = toFind[1];

            foreach (var (keyColor,valueClothes) in wardrobe)
            {
                Console.WriteLine($"{keyColor} clothes:");
                foreach (var (keyName,valueCount) in valueClothes)
                {
                    string isFound = colorToFind == keyColor && clothToFind == keyName ? "(found!)" : string.Empty;
                    Console.WriteLine($"* {keyName} - {valueCount} {isFound}");                       
                }
            }
        }
    }
}
