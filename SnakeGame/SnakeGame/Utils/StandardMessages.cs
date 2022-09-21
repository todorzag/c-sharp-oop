using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class StandardMessages
    {
        public static void PlayerFirstName()
        {
            Console.WriteLine("Please enter first name:");
        }

        public static void PlayerLastName()
        {
            Console.WriteLine("Please enter last name:");
        }

        public static void HasWalls()
        {
            Console.WriteLine("Would you like the board to have walls?");
        }
        
        public static void SnakeLength()
        {
            Console.WriteLine("How long would you like the snake to be?");
            Console.WriteLine("Minimum of 0, Maximum of 10");
        }

        public static void Error(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
