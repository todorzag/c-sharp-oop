using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class StandardMessages
    {
        public static string PlayerFirstName()
        {
            return ("Please enter first name:");
        }

        public static string PlayerLastName()
        {
            return ("Please enter last name:");
        }

        public static string HasWalls()
        {
            return ("Would you like the board to have walls?");
        }
        
        public static string SnakeLength()
        {
            return ("How long would you like the snake to be?" +
                "\nMinimum of 1, Maximum of 10");
        }

        public static string InitalSnakeLengthError()
        {
            return ("Snake length must be greater than 0 and less than 10!");
        }
    }
}
