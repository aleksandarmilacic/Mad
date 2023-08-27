using Mad.UI;

namespace Mad.MainGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            GameLoop gameLoop = new GameLoop();
            gameLoop.Run();
        }
    }
}