namespace Mad.GameEngine
{
    public class Map
    {
        public int Width { get; }
        public int Height { get; }
        public int[,] Grid { get; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new int[width, height];
        }
    }

}