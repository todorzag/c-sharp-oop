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
        public static IBonus Spawn(
            List<IPoint> snakeBody,
            IBonus bonus)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                bool outsideOfScoreRange = x > 0 && y > 10;

                bonus.Position = (x, y);

                if (!snakeBody.Any(x => x.EqualsPosition(bonus))
                    && outsideOfScoreRange)
                {
                    bonus.Render();

                    return bonus;
                }
            }
        }
    }
}