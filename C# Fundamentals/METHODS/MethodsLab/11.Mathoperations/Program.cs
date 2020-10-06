using System;

namespace _11.Mathoperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            char operattor = char.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculator(firstNum,secondNum,operattor));
        }

        static double Calculator(double num1, double num2, char operattor) 
        {
            double result=0;
            switch (operattor)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
            }
            return result;
        }
    }
}
