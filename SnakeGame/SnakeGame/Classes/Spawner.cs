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
            IOnConsume onConsumeStrategy)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                bool outsideOfScoreRange = x > 0 && y > 10;

                IBonus bonus = new Bonus(
                    x,
                    y,
                    onConsumeStrategy.Symbol,
                    onConsumeStrategy.ScoreValue,
                    onConsumeStrategy);

                if (!snakeBody.Any(x => x.Equals(bonus))
                    && outsideOfScoreRange)
                {
                    Writer.WriteAt(y, x, bonus.Symbol);

                    return bonus;
                }
            }
        }
    }
}