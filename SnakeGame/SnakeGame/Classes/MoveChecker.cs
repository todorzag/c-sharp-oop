using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    internal class MoveChecker
    {
        public static bool IsValid(List<IPoint> snakeBody, IPoint newPosition, bool gameHasWalls)
        {
            bool isValid = true;

            if (CheckIfOutOfBounds(newPosition) && !gameHasWalls)
            {
                isValid = false;
            }
            else if (CheckIfOutOfBounds(newPosition) && gameHasWalls)
            {
                throw new Exception("End Game");
            }
            else if (CheckIfHitItself(snakeBody, newPosition)) 
            {
                throw new Exception("End Game");
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