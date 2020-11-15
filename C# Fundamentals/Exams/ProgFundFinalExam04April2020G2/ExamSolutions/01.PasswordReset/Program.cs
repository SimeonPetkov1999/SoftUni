using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string password = Console.ReadLine();

            string[] commandArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commandArgs[0]!= "Done")
            {
                string command = commandArgs[0];
                if (command=="TakeOdd")
                {
                    for (int i = 1; i <password.Length; i+=2)
                    {
                        sb.Append(password[i]);
                    }

                    password = sb.ToString();
                    sb.Clear();
                    Console.WriteLine(password);
                }
                else if (command=="Cut")
                {
                    int index = int.Parse(commandArgs[1]);
                    int lenght = int.Parse(commandArgs[2]);
                    string substringToFind = password.Substring(index, lenght);
                    int startIndexOfSubstring = password.IndexOf(substringToFind);
                    password = password.Remove(startIndexOfSubstring, lenght);
                    Console.WriteLine(password);
                }
                else if (command== "Substitute")
                {
                    string subtringToFind = commandArgs[1];
                    string substringToReplace = commandArgs[2];
                    if (password.Contains(subtringToFind))
                    {
                        password = password.Replace(subtringToFind, substringToReplace);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }              
                }
                commandArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your password is: {password}");
         }
    }
}
