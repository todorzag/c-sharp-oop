using SnakeGame.Classes;
using SnakeGame.Constants;
using SnakeGame.Interfaces;
using System.Xml.Linq;

namespace SnakeGame.Utils
{
    internal class SnakeMoveChecker
    {
        public static TriState Check(
            List<IPoint> snakeBody,
            IPoint newPosition)
        {
            var state = TriState.True;

            if (!GameConfig.HasWalls && CheckIfOutOfBounds(newPosition))
            {
                state = TriState.False;
            }
            else if (CheckIfOutOfBounds(newPosition) && GameConfig.HasWalls
                || CheckIfHitItself(snakeBody, newPosition))
            {
                state = TriState.GameEnding;
            }

            return state;
        }

        public static Directions FindSafeDirection(List<IPoint> snakeBody)
        {
            Directions direction = Directions.RightArrow;
            (int x, int y) = snakeBody[0].Position;

            if (Check(snakeBody, Factory.CreatePoint(x, y + 1)) != TriState.GameEnding)
            {
                direction = Directions.RightArrow;
            }
            else if (Check(snakeBody, Factory.CreatePoint(x, y - 1)) != TriState.GameEnding)
            {
                direction = Directions.LeftArrow;
            }
            else if (Check(snakeBody, Factory.CreatePoint(x + 1, y)) != TriState.GameEnding)
            {
                direction = Directions.DownArrow;
            }
            else if (Check(snakeBody, Factory.CreatePoint(x - 1, y)) != TriState.GameEnding)
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