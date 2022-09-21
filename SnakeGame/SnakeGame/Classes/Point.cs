using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public (int, int) Position { get => (X, Y); }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(IPoint point)
        {
            return (Position == point.Position);
        }
    }
}
