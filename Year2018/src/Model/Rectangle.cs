namespace AdventOfCode.Year2018.Model
{
    public record Rectangle
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public string RootData { get; }

        public Rectangle(int x, int y, int width, int height, string rootData)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            RootData = rootData;
        }
    }
}
