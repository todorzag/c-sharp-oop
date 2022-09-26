using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    public class Spawner
    {
        public static ISpawnable SpawnApple(List<IPoint> snakeBody)
        {
            ISpawnable spawnable = Factory.CreateApple(0, 0);

            return SpawnObject(snakeBody, spawnable);
        }

        public static ISpawnable SpawnDollar(List<IPoint> snakeBody)
        {
            ISpawnable spawnable = Factory.CreateDollar(0, 0);

            return SpawnObject(snakeBody, spawnable);
        }

        private static ISpawnable SpawnObject(List<IPoint> snakeBody, ISpawnable spawnable)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                spawnable.Position = (x, y);

                if (!snakeBody.Any(x => x.Equals(spawnable)))
                {
                    Writer.WriteAt(y, x, spawnable.Symbol);

                    return spawnable;
                }
            }
        }
    }
}
