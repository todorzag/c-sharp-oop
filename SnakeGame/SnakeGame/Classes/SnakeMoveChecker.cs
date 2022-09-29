using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    internal class SnakeMoveChecker
    {
        public static bool IsValid(
            ISnake snake, IPoint newPosition, bool gameHasWalls)
        {
            bool isValid = true;

            if (!gameHasWalls && CheckIfOutOfBounds(newPosition))
            {
                isValid = false;
            }
            else if (CheckIfOutOfBounds(newPosition) && gameHasWalls
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
    }
}