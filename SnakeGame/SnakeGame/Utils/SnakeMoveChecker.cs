using SnakeGame.Classes;
using SnakeGame.Constants;
using SnakeGame.Interfaces;
using System.Xml.Linq;

namespace SnakeGame.Utils
{
    internal class SnakeMoveChecker
    {
        public static bool? Check(
            ISnake snake, IPoint newPosition)
        {
            bool? isValid = true;

            if (!GameConfig.HasWalls && CheckIfOutOfBounds(newPosition))
            {
                isValid = false;
            }
            else if (CheckIfOutOfBounds(newPosition) && GameConfig.HasWalls
                || CheckIfHitItself(snake.Body, newPosition)
                || Validator.ValidateMaxSnakeLength(snake))
            {
                isValid = null;
            }

            return isValid;
        }

        public static Directions FindSafeDirection(ISnake snake)
        {
            Directions direction = Directions.RightArrow;
            (int x, int y) = snake.Head.Position;

            if (Check(snake, Factory.CreatePoint(x, y + 1)) != null)
            {
                direction = Directions.RightArrow;
            }
            else if (Check(snake, Factory.CreatePoint(x, y - 1)) != null)
            {
                direction = Directions.LeftArrow;
            }
            else if (Check(snake, Factory.CreatePoint(x + 1, y)) != null)
            {
                direction = Directions.DownArrow;
            }
            else if (Check(snake, Factory.CreatePoint(x - 1, y)) != null)
            {
                direction = Directions.UpArrow;
            }

            return direction;
        }

        private static bool CheckIfOutOfBounds(IPoint newPosition)
        {
            bool isOutOfBounds = false;

            bool boundX = newPosition.X < 0
                || newPosition.X > Console.WindowHeight - 1;

            bool boundY = newPosition.Y < 0
                || newPosition.Y > Console.WindowWidth - 1;

            if (boundX || boundY) { isOutOfBounds = true; }

            return isOutOfBounds;
        }

        private static bool CheckIfHitItself(List<IPoint> snakeBody, IPoint newPosition)
        {
            foreach (var snakePart in snakeBody.Skip(1))
            {
                if (newPosition.Position == snakePart.Position)
                {
                    return true;
                }
            }

            return false;
        }
    }
}