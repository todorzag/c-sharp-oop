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
        public static IBonus SpawnApple(List<IPoint> snakeBody)
        {
            IBonus spawnable = Factory.CreateApple(0, 0);

            return SpawnObject(snakeBody, spawnable);
        }

        public static IBonus SpawnDollar(List<IPoint> snakeBody)
        {
            IBonus spawnable = Factory.CreateDollar(0, 0);

            return SpawnObject(snakeBody, spawnable);
        }

        private static IBonus SpawnObject(List<IPoint> snakeBody, IBonus spawnable)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                bool outsideOfScoreRange = x > 0 && y > 10;

                spawnable.Position = (x, y);

                if (!snakeBody.Any(x => x.Equals(spawnable))
                    && outsideOfScoreRange)
                {
                    Writer.WriteAt(y, x, spawnable.Symbol);

                    return spawnable;
                }
            }
        }
    }
}
