using System;

namespace _02.EnglishNameOfTheLastDigit
{
    class Program
    {
        static string LastDigitInEnglish(string s)
        {
            int lastDigit = s.Length - 1;
            string lastDigitInEnglish = null;

            switch (s[lastDigit])
            {
                case '0':
                    lastDigitInEnglish = "zero";
                    break;
                case '1':
                    lastDigitInEnglish = "one";
                    break;
                case '2':
                    lastDigitInEnglish = "two";
                    break;
                case '3':
                    lastDigitInEnglish = "three";
                    break;
                case '4':
                    lastDigitInEnglish = "four";
                    break;
                case '5':
                    lastDigitInEnglish = "five";
                    break;
                case '6':
                    lastDigitInEnglish = "six";
                    break;
                case '7':
                    lastDigitInEnglish = "seven";
                    break;
                case '8':
                    lastDigitInEnglish = "eight";
                    break;
                case '9':
                    lastDigitInEnglish = "nine";
                    break;
            }

            return lastDigitInEnglish;

        }
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();
            
            Console.WriteLine(LastDigitInEnglish(inputNum));
        }
    }
}
