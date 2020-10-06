using System;
using System.Linq;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (!CheckNumOfCharacters(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!CheckForLettersAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!CheckForNumOfDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (CheckNumOfCharacters(password)&& CheckForLettersAndDigits(password)&& CheckForNumOfDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool CheckNumOfCharacters(string pass)
        {
            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckForLettersAndDigits(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                string numsAndLetters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890";
                int currentDigit = pass[i];             
                if (numsAndLetters.Contains((char)currentDigit))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckForNumOfDigits(string pass)
        {
            int digits = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                int currentDigit = pass[i];
                if (currentDigit >= 48 && currentDigit <= 57)
                {
                    digits++;
                }
            }
            if (digits >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
