using SnakeGame.Classes;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class Spawner
    {
        private static Random _random = new Random();

        public static IBonus SetRandomPosition(
            List<IPoint> snakeBody,
            IBonus bonus)
        {
            while (true)
            {
                int x = _random.Next(1, Console.WindowHeight - 1);
                int y = _random.Next(1, Console.WindowWidth - 1);

                IBonusesHandler bonusesHandler = Factory.GetBonusesHandler();
                bool outsideOfScoreRange = x > 0 && y > 10;

                bonus.Position = (x, y);

                if ((snakeBody.Any(x => x.EqualsPosition(bonus)) == false)
                    && bonusesHandler.OnBonus(bonus) == false
                    && outsideOfScoreRange)
                {
                    return bonus;
                }
            }
        }
    }
}