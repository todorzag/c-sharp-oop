using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class FoodSpawner
    {
        public static IPoint SpawnApple(List<IPoint> snakeBody)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                IPoint apple = Factory.CreatePoint(x, y);

                if (!snakeBody.Any(x => x.Position == apple.Position))
                {
                    Writer.WriteAt(y, x, "@");

                    return apple;
                }
            }
        }
    }
}
