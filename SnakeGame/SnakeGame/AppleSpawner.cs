using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class AppleSpawner
    {
        public static Random Random = new Random();
        public (int, int) Position;

        public void SpawnApple(Snake snake)
        {
            while (true)
            {
                int x = Random.Next(1, Console.WindowHeight - 1);
                int y = Random.Next(1, Console.WindowWidth - 1);

                Position = (x, y);

                if (!snake.CheckSpawnOnSnake(this))
                {
                    Console.SetCursorPosition(y, x);
                    Console.Write("@");
                    break;
                }
            }
        }
    }
}
