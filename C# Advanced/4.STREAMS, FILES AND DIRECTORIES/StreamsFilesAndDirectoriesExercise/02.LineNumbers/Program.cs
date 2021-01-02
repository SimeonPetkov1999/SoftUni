using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllLines("./text.txt");
            for (int i = 0; i < file.Length; i++)
            {
                var currentLine = file[i];
                int countLetters = GetCountOfLetters(currentLine);
                int countMarks = GetCountOfMarks(currentLine);
                string result = $"Line {i + 1}: - {currentLine} ({countLetters})({countMarks})";
                File.AppendAllText("./output.txt",result);
            }
        }
        static int GetCountOfLetters(string text) 
        {
            int count = 0;
            foreach (var item in text)
            {
                if (char.IsLetter(item))
                {
                    count++;
                }
            }
            return count;
        }
        static int GetCountOfMarks(string text)
        {
            int count = 0;
            foreach (var item in text)
            {
                if (char.IsPunctuation(item))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
