using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfOpeningBrackets = 0;
            int numberOfClosingBrackets = 0;
            int checkForTwoOpenings = 0;
            int checkForTwoClosings = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input=="(" || input ==")")
                {
                    if (input == "(")
                    {
                        checkForTwoClosings = 0;
                        checkForTwoOpenings++;
                        if (checkForTwoOpenings==2)
                        {
                            Console.WriteLine("UNBALANCED");
                            Environment.Exit(0);
                        }
                        numberOfOpeningBrackets++;
                    }
                    else if (input == ")")
                    {
                        
                        checkForTwoOpenings = 0;
                        checkForTwoClosings++;
                        if (checkForTwoClosings == 2)
                        {
                            Console.WriteLine("UNBALANCED");
                            Environment.Exit(0);
                        }
                        numberOfClosingBrackets++;
                    }
                }            
            }
            if (numberOfClosingBrackets == numberOfOpeningBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }       
        }
    }
}
