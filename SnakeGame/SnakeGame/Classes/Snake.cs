using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    public class Snake : ISnake, IRenderable
    {
        private IPoint _lastBodyPart =
            Factory.CreatePoint(0, 0);

        private IPoint _newPosition =
            Factory.CreatePoint(0, 0);

        public bool IsAlive { get; set; } = true;

        public int MaxLength 
        { 
            get
            {
                return Console.WindowHeight - 1 * Console.WindowWidth - 1;
            }
        }

        public IPoint Head { get => Body[0]; }
        public List<IPoint> Body { get; private set; }
        public Directions Direction { get; set; }
            = Directions.RightArrow;
        
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
                    Writer.ConsoleWriteAt(Body[i].Y, Body[i].X, "●");
                }
                else
                {
                    Writer.ConsoleWriteAt(Head.Y, Head.X, "○");
                }
            }
        }

        public void AddPart()
        {
            (int x, int y) = _lastBodyPart.Position;
            Body.Add(Factory.CreatePoint(x, y));
        }

        public void RemoveTail()
        {
            ClearTailFromScreen();
            Body.RemoveAt(Body.Count - 1);
        }

        public void Move()
        {
            switch (Direction)
            {
                case Directions.RightArrow:
                    MoveY(1);
                    break;

                case Directions.LeftArrow:
                    MoveY(-1);
                    break;

                case Directions.DownArrow:
                    MoveX(1);
                    break;

                case Directions.UpArrow:
                    MoveX(-1);
                    break;
            }
        }

        private void MoveX(int value)
        {
            _newPosition.Position = (Head.X + value, Head.Y);

            var isValid = SnakeMoveChecker.Check(this, _newPosition);

            if (isValid == true)
            {
                Head.X += value;
            }
            else if (isValid == false)
            {
                Teleport();
            }
            else
            {
                IsAlive = false;
            }
        }

        private void MoveY(int value)
        {
            _newPosition.Position = (Head.X, Head.Y + value);

            var isValid = SnakeMoveChecker.Check(this, _newPosition);

            if (isValid == true)
            {
                Head.Y += value;
            }
            else if (isValid == false)
            {
                Teleport();
            }
            else
            {
                IsAlive = false;
            }
        }

        public void UpdateBodyPosition()
        {
            ClearTailFromScreen();

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
                snakeParts.Add(Factory.CreatePoint(1,i));
            }

            return snakeParts;
        }

        private void ClearTailFromScreen()
        {
            // Save last snake part position
            (int x, int y) = Body.Last().Position;
            _lastBodyPart.Position = (x, y);

            Writer.ConsoleWriteAt(y, x, " ");
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
