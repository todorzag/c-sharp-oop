using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public class SnakePart : ISnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public (int, int) Position { get => (X, Y); }

        public SnakePart(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
