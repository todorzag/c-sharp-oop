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
        public static Dictionary<string, Func<int,int, ISpawnable>> spawnables 
            = new Dictionary<string, Func<int, int, ISpawnable>>
            {
                {"apple", (int x, int y) => Factory.CreateApple(x, y) },
                {"dollar", (int x, int y) => Factory.CreateDollar(x, y) }
            };

        public static ISpawnable Spawn(string toSpawn, List<IPoint> snakeBody)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                ISpawnable spawnable = spawnables[toSpawn](x, y);

                if (!snakeBody.Any(x => x.Equals(spawnable)))
                {
                    spawnable.Render();

                    return spawnable;
                }
            }
        }
    }
}
