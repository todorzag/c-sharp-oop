namespace SnakeGame
{
    public class Snake
    {
        public SnakePart SnakeHead;
        public bool IsAlive = true;
        private List<SnakePart> _snakeBody;
        private (int, int) lastSnakePartPosition;

        public int SnakePartsCount 
        {
            get => _snakeBody.Count;
        }

        public int Score
        {
            get => SnakePartsCount - 3;
        }

        public (int, int) CurrentPosition
        {
            get => SnakeHead.Position;
        }

        public Snake()
        {
            SnakeHead = new SnakePart(1, 4, "○");

            _snakeBody = new List<SnakePart>
            {
                {new SnakePart(1,3)},
                {new SnakePart(1,2)},
                {new SnakePart(1,1)},
            };
        }

        public void RenderSnake()
        {
            WriteAt(SnakeHead.Y, SnakeHead.X, SnakeHead.Symbol);

            foreach (var snakePart in _snakeBody)
            {
                WriteAt(snakePart.Y, snakePart.X, snakePart.Symbol);
            }
        }

        public void ClearLastSnakePart()
        {
            // Save last snake part position
            SnakePart lastSnakePart = _snakeBody.Last();
            (int x, int y) = lastSnakePart.Position;
            lastSnakePartPosition = (x, y);

            WriteAt(y, x, " ");
        }

        public bool CheckIfOutOfBounds(int consoleHeight, int consoleWidth)
        {
            bool isOutOfBounds = false;

            bool boundX = SnakeHead.X < 0 || SnakeHead.X > consoleHeight - 1;
            bool boundY = SnakeHead.Y < 0 || SnakeHead.Y > consoleWidth - 1;

            if (boundX || boundY) { isOutOfBounds = true; }

            return isOutOfBounds;
        }

        public void Teleport(int consoleHeight, int consoleWidth)
        {
            int x = SnakeHead.X;
            int y = SnakeHead.Y;

            int bottomBorderIndex = consoleHeight - 1;
            int rightBorderIndex = consoleWidth - 1;

            if (x < 0)
            {
                SnakeHead.X = bottomBorderIndex;
            }
            else if (x > bottomBorderIndex)
            {
                SnakeHead.X = 0;
            }
            else if (y < 0)
            {
                SnakeHead.Y = rightBorderIndex;
            }
            else if (y > rightBorderIndex)
            {
                SnakeHead.Y = 0;
            }
        }

        public bool CheckIfHitItself()
        {
            foreach (var snakePart in _snakeBody)
            {
                if (SnakeHead.Position == snakePart.Position)
                {
                    return true;
                }
            }

            return false;
        }

        public bool OnApple((int,int) applePosition)
        {
            return applePosition == SnakeHead.Position;
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

        public void MoveX(int x)
        {
            SnakeHead.X += x;
        }

        public void MoveY(int y)
        {
            SnakeHead.Y += y;
        }

        public void UpdateBodyPosition()
        {
            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                int x = _snakeBody[i - 1].X;
                int y = _snakeBody[i  - 1].Y;

                _snakeBody[i].X = x;
                _snakeBody[i].Y = y;
            }

            _snakeBody[0].X = SnakeHead.X;
            _snakeBody[0].Y = SnakeHead.Y;
        }

        private void WriteAt(int y, int x, string symbol)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(symbol);
        }

    }
}
