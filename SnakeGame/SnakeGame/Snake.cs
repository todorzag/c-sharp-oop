using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        private List<SnakePart> _snakeBody;
        private SnakeHead _snakeHead;

        public Snake()
        {
            _snakeHead = new SnakeHead(1, 4);

            _snakeBody = new List<SnakePart>
            {
                {new SnakePart(1,3)},
                {new SnakePart(1,2)},
                {new SnakePart(1,1)},
            };
        }

        public void RenderSnake(string[,] board)
        {
            board[_snakeHead.X, _snakeHead.Y] = _snakeHead.Symbol;

            foreach (var snakePart in _snakeBody)
            {
                board[snakePart.X, snakePart.Y] = snakePart.Symbol;
            }
        }

        public void ClearSnakePart(string[,] board)
        {
            SnakePart lastPart = _snakeBody[_snakeBody.Count - 1];

            int x = lastPart.X;
            int y = lastPart.Y;

            board[x, y] = " ";
        }

        public bool IsOutOfBounds(string[,] board) 
            => _snakeHead.CheckOutOfBounds(board);

        public bool HitItself()
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
    }
}
