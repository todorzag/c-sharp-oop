using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeHead 
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Symbol { get; }
        public (int, int) Position { get => (X, Y); }

        public SnakeHead(int x, int y)
        {
            X = x;
            Y = y;
            Symbol = "○";
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

        public bool CheckOutOfBounds(string[,] board)
        {
            bool isOutOfBoundX = X == 0 || X == board.GetLength(0) - 1;
            bool isOutOfBoundY = Y == 0 || Y == board.GetLength(1) - 1;

            if (isOutOfBoundX || isOutOfBoundY) { return true; }

            return false;
        }
    }
}
