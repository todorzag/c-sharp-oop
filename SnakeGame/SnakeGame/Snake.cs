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

        public bool CheckIfOutOfBounds() 
            => _snakeHead.CheckIfOutOfBounds();

        public void Teleport()
            => _snakeHead.Teleport();

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

        public void EatApple()
        {
            (int x, int y) = lastSnakePartPosition;
            _snakeBody.Add(new SnakePart(x, y));
        }

        public bool OnApple((int,int) applePosition)
        {
            return applePosition == _snakeHead.Position;
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
