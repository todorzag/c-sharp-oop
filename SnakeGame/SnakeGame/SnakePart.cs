using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void TurnRight()
        {
            Y++;
        }

        public void TurnLeft()
        {
            Y--;
        }

        public void TurnDown()
        {
            X++;
        }

        public void TurnUp()
        {
            X--;
        }

        public void ChangePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
