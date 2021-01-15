using System;
using System.Linq;

namespace _2.PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var recCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var topLeftPointRec = new Point(recCoordinates[0], recCoordinates[1]);
            var bottomRightPointRec = new Point(recCoordinates[2], recCoordinates[3]);

            var rectangle = new Rectangle(topLeftPointRec, bottomRightPointRec);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <n; i++)
            {
                var pointCoordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var point = new Point(pointCoordinates[0], pointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(point));
            }

        }
    }
}
