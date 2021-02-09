namespace SimpleSnakeWithBorders
{
    using Core;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(80, 30);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(snake, wall);
            engine.Run();
        }
    }
}