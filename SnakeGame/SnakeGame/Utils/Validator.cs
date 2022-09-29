using SnakeGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class Validator
    {
        public static bool ValidateInitalSnakeLength(int snakeLength)
        {
            return snakeLength > 0 && snakeLength < 11;
        }

        public static bool ValidateMaxSnakeLength(ISnake snake)
        {
            return snake.Body.Count == snake.MaxLength;
        }
    }
}
