using System;

namespace _01.EncryptSortAndPrintArray
{
    class Program
    {
         static void BubbleSortInt (int[] arr) 
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] strings = new string[n];
            int[] codes = new int[n];
            int sum = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = Console.ReadLine();
            }
            for (int i = 0; i < codes.Length; i++)
            {
                string currentString = strings[i];
                for (int j = 0; j < currentString.Length; j++)
                {
                    bool isVowel = currentString[j] == 'a' || currentString[j] == 'e' || currentString[j] == 'i' || currentString[j] == 'o' || currentString[j] == 'u' || currentString[j] == 'A' || currentString[j] == 'E' || currentString[j] == 'I' || currentString[j] == 'O' || currentString[j] == 'U';
                                
                    if (isVowel)
                    {
                        sum += currentString[j] * currentString.Length;
                    }
                    else
                    {
                        sum += currentString[j] / currentString.Length;
                    }
                }
                codes[i] = sum;
                sum = 0;
            }
            BubbleSortInt(codes);        
            foreach (var item in codes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
