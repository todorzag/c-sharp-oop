using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class SnakeLengthValidator 
    {
        public static bool ValidateInitalSnakeLength(int snakeLength)
        {
            return snakeLength > 0 && snakeLength < 11;
        }

        public static bool ValidateMaxSnakeLength(List<IPoint> snakeBody)
        {
            int maxLength = Console.WindowHeight - 1 * Console.WindowWidth - 1;

            return snakeBody.Count == maxLength;
        }
    }
}
