namespace SnakeGame
{
    public class Snake
    {
        public ISnakePart Head { get => _snakeBody[0]; }

        private List<ISnakePart> _snakeBody;
        private (int, int) _lastSnakePartPosition;
        private int _startingSnakeLenght;

        private int _consoleHeight = Console.WindowHeight;
        private int _consoleWidth = Console.WindowWidth;

        public bool GameHasWalls { get; set; }

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

        public void RenderSnake()
        {
            for (int i = 0; i < SnakePartsCount; i++)
            {
                if (i != 0)
                {
                    WriteAt(_snakeBody[i].Y, _snakeBody[i].X, "●");
                }
                else
                {
                    WriteAt(Head.Y, Head.X, "○");
                }
            }
        }

        public void AddSnakePart()
        {
            (int x, int y) = _lastSnakePartPosition;
            _snakeBody.Add(new SnakePart(x, y));
        }

        public bool CheckSpawnOnSnake((int, int) applePosition)
        {
            return _snakeBody.Any(x => x.Position == applePosition);
        }

        public void MoveX(int x)
        {
            Head.X += x;

            if (CheckTeleport(GameHasWalls))
            {
                Teleport();
            }

            if (MoveEndsGame(GameHasWalls))
            {
                throw new Exception("End Game");
            }
        }

        public void MoveY(int y)
        {
            Head.Y += y;

            if (CheckTeleport(GameHasWalls))
            {
                Teleport();
            }

            if (MoveEndsGame(GameHasWalls))
            {
                throw new Exception("End Game");
            }
        }

        public void UpdateBodyPosition()
        {
            ClearLastSnakePart();

            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                int x = _snakeBody[i - 1].X;
                int y = _snakeBody[i - 1].Y;

                _snakeBody[i].X = x;
                _snakeBody[i].Y = y;
            }
        }

        private List<ISnakePart> GenerateSnakeBody(int snakeLenght)
        {
            List<ISnakePart> snakeParts = new List<ISnakePart>();

            for (int i = snakeLenght; i >= 1; i--)
            {
                snakeParts.Add(new SnakePart(1, i));
            }

            return snakeParts;
        }

        private bool MoveEndsGame(bool hasWalls)
        {
            bool result = false;

            if (CheckIfOutOfBounds() && hasWalls)
            {
                result = true;
            }
            else if (CheckIfHitItself())
            {
                result = true;
            }

            return result;
        }

        private bool CheckTeleport(bool hasWalls)
        {
            return CheckIfOutOfBounds() && !hasWalls;
        }

        private void WriteAt(int y, int x, string symbol)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(symbol);
        }

        private void ClearLastSnakePart()
        {
            // Save last snake part position
            ISnakePart lastSnakePart = _snakeBody.Last();
            (int x, int y) = lastSnakePart.Position;
            _lastSnakePartPosition = (x, y);

            WriteAt(y, x, " ");
        }

        private bool CheckIfOutOfBounds()
        {
            bool isOutOfBounds = false;

            bool boundX = Head.X < 0 || Head.X > _consoleHeight - 1;
            bool boundY = Head.Y < 0 || Head.Y > _consoleWidth - 1;

            if (boundX || boundY) { isOutOfBounds = true; }

            return isOutOfBounds;
        }

        private void Teleport()
        {
            int bottomBorderIndex = _consoleHeight - 1;
            int rightBorderIndex = _consoleWidth - 1;

            if (Head.X < 0)
            {
                Head.X = bottomBorderIndex;
            }
            else if (Head.X > bottomBorderIndex)
            {
                Head.X = 0;
            }
            else if (Head.Y < 0)
            {
                Head.Y = rightBorderIndex;
            }
            else if (Head.Y > rightBorderIndex)
            {
                Head.Y = 0;
            }
        }

        private bool CheckIfHitItself()
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
    }
}
