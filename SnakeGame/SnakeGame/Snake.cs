using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        private List<SnakePart> _snakeBody;
        private SnakePart _snakeHead;
        private (int, int) lastSnakePartPosition;

        public int SnakePartsCount 
        {
            get => _snakeBody.Count;
        }

        public int Score
        {
            get => SnakePartsCount - 3;
        }

        public Snake()
        {
            _snakeHead = new SnakePart(1, 4, "○");

            _snakeBody = new List<SnakePart>
            {
                {new SnakePart(1,3)},
                {new SnakePart(1,2)},
                {new SnakePart(1,1)},
            };
        }

        public void RenderSnake()
        {
            WriteAt(_snakeHead.Y, _snakeHead.X, _snakeHead.Symbol);

            foreach (var snakePart in _snakeBody)
            {
                WriteAt(snakePart.Y, snakePart.X, snakePart.Symbol);
            }
        }

        public void ClearLastSnakePart()
        {
            SnakePart lastSnakePart = _snakeBody.Last();
            (int x, int y) = lastSnakePart.Position;
            lastSnakePartPosition = (x, y);

            WriteAt(y, x, " ");
        }

        public bool CheckIfOutOfBounds(int consoleHeight, int consoleWidth)
        {
            bool isOutOfBounds = false;

            bool boundX = _snakeHead.X < 0 || _snakeHead.X > consoleHeight - 1;
            bool boundY = _snakeHead.Y < 0 || _snakeHead.Y > consoleWidth - 1;

            if (boundX || boundY) { isOutOfBounds = true; }

            return isOutOfBounds;
        }

        public void Teleport(int consoleHeight, int consoleWidth)
        {
            int x = _snakeHead.X;
            int y = _snakeHead.Y;

            int bottomBorderIndex = consoleHeight - 1;
            int rightBorderIndex = consoleWidth - 1;

            if (x < 0)
            {
                _snakeHead.X = bottomBorderIndex;
            }
            else if (x > bottomBorderIndex)
            {
                _snakeHead.X = 0;
            }
            else if (y < 0)
            {
                _snakeHead.Y = rightBorderIndex;
            }
            else if (y > rightBorderIndex)
            {
                _snakeHead.Y = 0;
            }
        }

        public bool CheckIfHitItself()
        {
            foreach (var snakePart in _snakeBody)
            {
                if (_snakeHead.Position == snakePart.Position)
                {
                    return true;
                }
            }

            return false;
        }

        public void Turn(string direction)
        {
            UpdateBodyPosition();

            switch (direction)
            {
                case "RightArrow":
                    _snakeHead.TurnRight();
                    break;

                case "LeftArrow":
                    _snakeHead.TurnLeft();
                    break;

                case "DownArrow":
                    _snakeHead.TurnDown();
                    break;

                case "UpArrow":
                    _snakeHead.TurnUp();
                    break;
            }
        }

        public bool OnApple((int,int) applePosition)
        {
            return applePosition == _snakeHead.Position;
        }

        public void EatApple()
        {
            (int x, int y) = lastSnakePartPosition;
            _snakeBody.Add(new SnakePart(x, y));
        }

        public bool CheckSpawnOnSnake((int, int) applePosition)
        {
            return _snakeBody.Any(x => x.Position == applePosition);
        }

        private void UpdateBodyPosition()
        {
            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                int x = _snakeBody[i - 1].X;
                int y = _snakeBody[i  - 1].Y;

                _snakeBody[i].ChangePosition(x, y);
            }

            _snakeBody[0].ChangePosition(_snakeHead.X, _snakeHead.Y);
        }

        private void WriteAt(int y, int x, string symbol)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(symbol);
        }
    }
}
