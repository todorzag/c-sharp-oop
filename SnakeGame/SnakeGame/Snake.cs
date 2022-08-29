﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        private List<SnakePart> _snakeBody;
        private SnakePart _snakeHead;
        private (int, int) lastSnakePosition;

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
            SnakePart lastSnakePart = _snakeBody.Last();

            (int x, int y) = lastSnakePart.Position;

            lastSnakePosition = (x, y);

            board[x, y] = " ";
        }

        public bool ChexkIfOutOfBounds(string[,] board) 
            => _snakeHead.CheckIfOutOfBounds(board);

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

        public void AddSnakePart()
        {
            (int x, int y) = lastSnakePosition;

            _snakeBody.Add(new SnakePart(x, y));
        }

        public bool OnApple(string[,] board) 
            => board[_snakeHead.X, _snakeHead.Y] == "@";

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