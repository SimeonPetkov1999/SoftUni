using System;
using System.Linq;

namespace _02.EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] giftsList = Console.ReadLine().Split();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "No")
            {
                string gift = command[1];

                switch (command[0])
                {
                    case "OutOfStock":
                        if (giftsList.Contains(gift))
                        {
                            giftsList = giftsList.Select(item =>
                           {
                               if (item == gift)
                               {
                                   return "None";
                               }
                               return item;
                           }).ToArray();
                        }
                        break;
                    case "Required":
                        int index = int.Parse(command[2]);
                        if (index >= 0 && index <= giftsList.Length - 1)
                        {
                            giftsList[index] = gift;
                        }
                        break;
                    case "JustInCase":
                        giftsList[giftsList.Length - 1] = gift;
                        break;
                }
                command = Console.ReadLine().Split();
            }

            for (int i = 0; i < giftsList.Length; i++)
            {
                if (giftsList[i] != "None")
                {
                    Console.Write($"{giftsList[i]} ");
                }
            }
        }
    }
}
