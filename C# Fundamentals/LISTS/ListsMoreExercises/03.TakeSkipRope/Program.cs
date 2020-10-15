using System;
using System.Collections.Generic;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> numbers = GetNums(text);
            List<char> nonNumbers = GetNonNums(text);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            TakeSkip(takeList, skipList, numbers);

            int Totalskipped = 0;
            string result = string.Empty;
            for (int i = 0; i < skipList.Count; i++)
            {
                Totalskipped += skipList[i];

            }

        }

        static List<int> GetNums(string text)
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 48 && text[i] <= 57)
                {
                    nums.Add(int.Parse(text[i].ToString()));
                }
            }

            return nums;
        }

        static List<char> GetNonNums(string text)
        {
            List<char> nonNums = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] < 48 || text[i] > 57)
                {
                    nonNums.Add(text[i]);
                }
            }

            return nonNums;
        }

        static void TakeSkip(List<int> take, List<int> skip, List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(nums[i]);
                }
                else
                {
                    skip.Add(nums[i]);
                }
            }
        }
    }
}
