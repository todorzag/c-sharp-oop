namespace SnakeGame
{
    public class Snake
    {
        public SnakePart Head { get => _snakeBody[0]; }
        public bool GameHasWalls;

        private List<SnakePart> _snakeBody;
        private (int, int) _lastSnakePartPosition;
        private int _startingSnakeLenght;

        private int _consoleHeight = Console.WindowHeight;
        private int _consoleWidth = Console.WindowWidth;

        public int SnakePartsCount 
        {
            get => _snakeBody.Count;
        }

        public int Score
        {
            get => SnakePartsCount - _startingSnakeLenght;
        }

        public (int, int) CurrentPosition
        {
            get => Head.Position;
        }

        public Snake(int snakeLenght)
        {
            _snakeBody = GenerateSnakeBody(snakeLenght);
            _startingSnakeLenght = snakeLenght;
        }

        private List<SnakePart> GenerateSnakeBody(int snakeLenght)
        {
            List<SnakePart> snakeParts = new List<SnakePart>();

            for (int i = snakeLenght; i >= 1; i--)
            {
                if (i != snakeLenght)
                {
                    snakeParts.Add(new SnakePart(1, i, "●"));
                    
                }
                else
                {
                    snakeParts.Add(new SnakePart(1, i, "○"));
                }
            }

            return snakeParts;
        }

        public void RenderSnake()
        {
            WriteAt(Head.Y, Head.X, Head.Symbol);

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
            _lastSnakePartPosition = (x, y);

            WriteAt(y, x, " ");
        }

        public bool CheckIfOutOfBounds()
        {
            bool isOutOfBounds = false;

            bool boundX = Head.X < 0 || Head.X > _consoleHeight - 1;
            bool boundY = Head.Y < 0 || Head.Y > _consoleWidth - 1;

            if (boundX || boundY) { isOutOfBounds = true; }

            return isOutOfBounds;
        }

        public void Teleport()
        {
            int x = Head.X;
            int y = Head.Y;

            int bottomBorderIndex = _consoleHeight - 1;
            int rightBorderIndex = _consoleWidth - 1;

            if (x < 0)
            {
                Head.X = bottomBorderIndex;
            }
            else if (x > bottomBorderIndex)
            {
                Head.X = 0;
            }
            else if (y < 0)
            {
                Head.Y = rightBorderIndex;
            }
            else if (y > rightBorderIndex)
            {
                Head.Y = 0;
            }
        }

        public bool CheckIfHitItself()
        {
            foreach (var snakePart in _snakeBody.Skip(1))
            {
                if (Head.Position == snakePart.Position)
                {
                    return true;
                }
            }

            return false;
        }

        public bool OnApple((int,int) applePosition)
        {
            return applePosition == Head.Position;
        }

        public void EatApple()
        {
            (int x, int y) = _lastSnakePartPosition;
            _snakeBody.Add(new SnakePart(x, y, "●"));
        }

        public bool CheckSpawnOnSnake((int, int) applePosition)
        {
            return _snakeBody.Any(x => x.Position == applePosition);
        }

        public void MoveX(int x)
        {
            Head.X += x;

            if (ShouldEndGame())
            {
                throw new Exception("End Game");
            }

            if (ShouldTeleport())
            {
                Teleport();
            }
        }

        public void MoveY(int y)
        {
            Head.Y += y;

            if (ShouldEndGame())
            {
                throw new Exception("End Game");
            }

            if (ShouldTeleport())
            {
                Teleport();
            }
        }

        public void UpdateBodyPosition()
        {
            ClearLastSnakePart();

            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                int x = _snakeBody[i - 1].X;
                int y = _snakeBody[i  - 1].Y;

                _snakeBody[i].X = x;
                _snakeBody[i].Y = y;
            }

            _snakeBody[0].X = Head.X;
            _snakeBody[0].Y = Head.Y;
        }

        public bool ShouldEndGame()
        {
            bool result = false;

            if (CheckIfOutOfBounds())
            {
                if (GameHasWalls)
                {
                    result = true;
                }
            }
            else if (CheckIfHitItself())
            {
                result = true;
            }

            return result;
        }

        private bool ShouldTeleport()
        {
            bool result = false;

            if (CheckIfOutOfBounds())
            {
                if (!GameHasWalls)
                {
                    result = true;
                }
            }

            return result;
        }

        private void WriteAt(int y, int x, string symbol)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(symbol);
        }

    }
}
