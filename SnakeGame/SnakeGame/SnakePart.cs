using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class SnakePart
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Symbol { get; }
        public (int, int) Position { get => (X, Y); }

        public SnakePart(int x, int y)
        {
            X = x;
            Y = y;
            Symbol = "●";
        }

        public void ChangePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
