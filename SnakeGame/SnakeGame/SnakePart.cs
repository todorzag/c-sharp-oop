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

        public bool CheckIfOutOfBounds(string[,] board)
        {
            bool isOutOfBoundX = X < 0 || X > board.GetLength(0) - 1;
            bool isOutOfBoundY = Y < 0 || Y > board.GetLength(1) - 1;

            if (isOutOfBoundX || isOutOfBoundY) { return true; }

            return false;
        }

        public void Teleport(string[,] board)
        {
            var bottomBorderIndex = board.GetLength(0) - 1;
            var rightBorderIndex = board.GetLength(1) - 1;

            if (X < 0)
            {
                X = bottomBorderIndex;
            }
            else if (X > bottomBorderIndex)
            {
                X = 0;
            }
            else if (Y < 0)
            {
                Y = rightBorderIndex;
            }
            else if (Y > rightBorderIndex)
            {
                Y = 0;
            }
        }
    }
}
