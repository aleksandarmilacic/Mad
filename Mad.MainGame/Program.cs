using Mad.UI;
using OpenTK.Windowing.Desktop;

namespace Mad.MainGame
{
    internal class Program
    {
        public static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(800, 600),
                Title = "Mad Game Engine"
            };

            var gameWindow = new GameWindow(GameWindowSettings.Default, nativeWindowSettings);

            var gameLoop = new GameLoop();

            gameWindow.UpdateFrame += (e) =>
            {
                gameLoop.Update((float)e.Time);
                gameWindow.SwapBuffers();
            };

            gameWindow.Run();
        }

    }
}