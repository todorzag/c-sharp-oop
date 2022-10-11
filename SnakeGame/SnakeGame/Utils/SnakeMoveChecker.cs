using SnakeGame.Classes;
using SnakeGame.Constants;
using SnakeGame.Interfaces;

namespace SnakeGame.Utils
{
    internal class SnakeMoveChecker
    {
        public static bool IsValid(
            ISnake snake, IPoint newPosition)
        {
            bool isValid = true;

            if (!GameConfig.HasWalls && CheckIfOutOfBounds(newPosition))
            {
                isValid = false;
            }
            else if (CheckIfOutOfBounds(newPosition) && GameConfig.HasWalls
                || CheckIfHitItself(snake.Body, newPosition)
                || Validator.ValidateMaxSnakeLength(snake))
            {
                throw new GameEndException();
            }

            return isValid;
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

        public static Directions GetSafeDirection(
            ISnake snake,
            int x,
            int y,
            int i)
        {
            Directions direction;

            try
            {
                IsValid(snake, Factory.CreatePoint(x, y));
                direction = (Directions)i;
            }
            catch (GameEndException)
            {
                return GetSafeDirection(snake, x, y - 1, i + 1);
                return GetSafeDirection(snake, x + 1, y, i + 2);
                return GetSafeDirection(snake, x - 1, y, i + 3);
            }

            return direction;
        }
    }
}