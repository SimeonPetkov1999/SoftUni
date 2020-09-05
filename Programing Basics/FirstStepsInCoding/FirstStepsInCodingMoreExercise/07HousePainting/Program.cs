using System;

namespace _07HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double heightHouseX = double.Parse(Console.ReadLine());
            double widthHouseY = double.Parse(Console.ReadLine());
            double heightRoofH = double.Parse(Console.ReadLine());

            double sideWall = heightHouseX * widthHouseY;
            double window = 2.25;
            double sideWalls = (sideWall * 2) - 2 * window;

            double backWall = heightHouseX * heightHouseX;
            double door = 2.4;
            double backFrontWalls = (backWall * 2) - door;

            double GreenPaintNeeded = (sideWalls + backFrontWalls) / 3.4;


            double sideWallRoof = 2 * (heightHouseX * widthHouseY);
            double trianglesRoof = 2 * ((heightHouseX * heightRoofH) / 2);

            double redPaintNeeded = (sideWallRoof + trianglesRoof) / 4.3;

            Console.WriteLine($"{GreenPaintNeeded:f2}");
            Console.WriteLine($"{redPaintNeeded:f2}");

        }
    }
}
