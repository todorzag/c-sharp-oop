using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class Validator
    {
        public static void ValidateSnakeLength(int snakeLength)
        {
            if (snakeLength < 0 || snakeLength > 10)
            {
                throw new ArgumentOutOfRangeException
                    ("Snake length must be greater than 0 and lesser than 10");
            };
        }
    }
}
