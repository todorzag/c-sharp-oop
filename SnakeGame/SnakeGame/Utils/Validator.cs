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
        public static bool ValidateInitalLength(int snakeLength)
        {
            return snakeLength > 0 && snakeLength < 11;
        }

        public static bool ValidateMaxLength(int snakeBodyCount)
        {
            int maxLength = Console.WindowHeight - 1 * Console.WindowWidth - 1;

            return snakeBodyCount == maxLength;
        }
    }
}
