namespace SnakeGame
{
    public class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Symbol { get; }
        public (int, int) Position { get => (X, Y); }

        public SnakePart(int x, int y)
            : this(x, y, "●")
        {
        }

        public SnakePart(int x, int y, string symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public bool OnApple((int, int) applePosition)
        {
            return applePosition == Position;
        }
    }
}
