using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    public class Snake : ISnake, IRenderable
    {
        private (int, int) _lastBodyPartPosition;
        private IPoint _newPosition =
            Factory.CreatePoint(0, 0);

        public int MaxLength 
        { 
            get
            {
                return Console.WindowHeight - 1 * Console.WindowWidth - 1;
            }
        }

        public IPoint Head { get => Body[0]; }
        public List<IPoint> Body { get; private set; }

        public Snake(int lenght)
        {
            Body = GenerateBody(lenght);
        }

        public void Render()
        {
            for (int i = 0; i < Body.Count; i++)
            {
                if (i != 0)
                {
                    Writer.WriteAt(Body[i].Y, Body[i].X, "●");
                }
                else
                {
                    Writer.WriteAt(Head.Y, Head.X, "○");
                }
            }
        }

        public void AddPart()
        {
            (int x, int y) = _lastBodyPartPosition;
            Body.Add(new Point(x, y));
        }

        public void Move(Directions direction, bool hasWalls)
        {
            switch (direction)
            {
                case Directions.RightArrow:
                    MoveY(1, hasWalls);
                    break;

                case Directions.LeftArrow:
                    MoveY(-1, hasWalls);
                    break;

                case Directions.DownArrow:
                    MoveX(1, hasWalls);
                    break;

                case Directions.UpArrow:
                    MoveX(-1, hasWalls);
                    break;
            }
        }

        private void MoveX(int value, bool gameHasWalls)
        {
            _newPosition.Position = (Head.X + value, Head.Y);

            if (SnakeMoveChecker.IsValid(this, _newPosition, gameHasWalls))
            {
                Head.X += value;
            }
            else
            {
                Teleport();
            }
        }

        private void MoveY(int value, bool gameHasWalls)
        {
            _newPosition.Position = (Head.X, Head.Y + value);

            if (SnakeMoveChecker.IsValid(this, _newPosition, gameHasWalls))
            {
                Head.Y += value;
            }
            else
            {
                Teleport();
            }
        }

        public void UpdateBodyPosition()
        {
            ClearLastBodyPart();

            for (int i = Body.Count - 1; i > 0; i--)
            {
                int x = Body[i - 1].X;
                int y = Body[i - 1].Y;

                Body[i].X = x;
                Body[i].Y = y;
            }
        }

        private List<IPoint> GenerateBody(int snakeLenght)
        {
            List<IPoint> snakeParts = new List<IPoint>();

            for (int i = snakeLenght; i >= 0; i--)
            {
                snakeParts.Add(new Point(1, i));
            }

            return snakeParts;
        }

        private void ClearLastBodyPart()
        {
            // Save last snake part position
            IPoint lastSnakePart = Body.Last();
            (int x, int y) = lastSnakePart.Position;
            _lastBodyPartPosition = (x, y);

            Writer.WriteAt(y, x, " ");
        }

        private void Teleport()
        {
            int bottomBorderIndex = Console.WindowHeight - 1;
            int rightBorderIndex = Console.WindowWidth - 1;

            if (_newPosition.X < 0)
            {
                Head.X = bottomBorderIndex;
            }
            else if (_newPosition.X > bottomBorderIndex)
            {
                Head.X = 0;
            }
            else if (_newPosition.Y < 0)
            {
                Head.Y = rightBorderIndex;
            }
            else if (_newPosition.Y > rightBorderIndex)
            {
                Head.Y = 0;
            }
        }
    }
}
