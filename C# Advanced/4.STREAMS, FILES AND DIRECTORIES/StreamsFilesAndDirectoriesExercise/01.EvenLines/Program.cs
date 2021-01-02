using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("./text.txt");
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var currentLine = input[i];
                    for (int j = 0; j < currentLine.Length; j++)
                    {
                        if (char.IsPunctuation(currentLine[j]))
                        {
                            sb.Append('@');
                        }
                        else
                        {
                            sb.Append(currentLine[j]);
                        }    
                    }                 
                    Console.WriteLine(string.Join(' ',sb.ToString().Split(' ').Reverse()));
                    sb.Clear();
                }
            }
        }
    }
}
