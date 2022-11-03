using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public (int, int) Position 
        { 
            get
            {
                return (X, Y);
            }

            set 
            {
                X = value.Item1;
                Y = value.Item2;
            }
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool EqualsPosition(IPoint point)
        {
            return (Position == point.Position);
        }
    }
}
