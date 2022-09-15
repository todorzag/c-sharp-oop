namespace SnakeGame
{
    public class Snake
    {
        public ISnakePart Head { get => _body[0]; }

        private List<ISnakePart> _body;
        private (int, int) _lastBodyPartPosition;
        private int _startingLenght;

        private int _consoleHeight = Console.WindowHeight;
        private int _consoleWidth = Console.WindowWidth;

        public int BodyPartsCount
        {
            get => _body.Count;
        }

        public int Score
        {
            get => BodyPartsCount - _startingLenght;
        }

        public (int, int) CurrentPosition
        {
            get => Head.Position;
        }

        public Snake(int lenght)
        {
            _body = GenerateBody(lenght);
            _startingLenght = lenght;
        }

        public void Render()
        {
            for (int i = 0; i < BodyPartsCount; i++)
            {
                if (i != 0)
                {
                    WriteAt(_body[i].Y, _body[i].X, "●");
                }
                else
                {
                    WriteAt(Head.Y, Head.X, "○");
                }
            }
        }

        public void AddPart()
        {
            (int x, int y) = _lastBodyPartPosition;
            _body.Add(new SnakePart(x, y));
        }

        public bool CheckSpawnOnBody((int, int) applePosition)
        {
            return _body.Any(x => x.Position == applePosition);
        }

        public void MoveX(int x, bool gameHasWalls)
        {
            Head.X += x;

            if (CheckTeleport(gameHasWalls))
            {
                Teleport();
            }

            if (MoveIsNotPossible(gameHasWalls))
            {
                throw new Exception("End Game");
            }
        }

        public void MoveY(int y, bool gameHasWalls)
        {
            Head.Y += y;

            if (CheckTeleport(gameHasWalls))
            {
                Teleport();
            }

            if (MoveIsNotPossible(gameHasWalls))
            {
                throw new Exception("End Game");
            }
        }

        public void UpdateBodyPosition()
        {
            ClearLastBodyPart();

            for (int i = _body.Count - 1; i > 0; i--)
            {
                int x = _body[i - 1].X;
                int y = _body[i - 1].Y;

                _body[i].X = x;
                _body[i].Y = y;
            }
        }

        private List<ISnakePart> GenerateBody(int snakeLenght)
        {
            List<ISnakePart> snakeParts = new List<ISnakePart>();

            for (int i = snakeLenght; i >= 1; i--)
            {
                snakeParts.Add(new SnakePart(1, i));
            }

            return snakeParts;
        }

        private bool MoveIsNotPossible(bool hasWalls)
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

        private void ClearLastBodyPart()
        {
            // Save last snake part position
            ISnakePart lastSnakePart = _body.Last();
            (int x, int y) = lastSnakePart.Position;
            _lastBodyPartPosition = (x, y);

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
            foreach (var snakePart in _body.Skip(1))
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
