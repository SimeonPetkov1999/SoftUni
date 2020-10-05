using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            Console.WriteLine(RectangleArea(width,heigth));

        }
        static int RectangleArea(int w, int h)
        {
            int result = w * h;
            return result;            
        }
    }
}
