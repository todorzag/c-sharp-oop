using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class Dollar : BasicBonus
    {
        public Dollar(int x, int y) : base(x, y)
        {
        }

        public override string Symbol { get => "$"; }

        public override int ScoreValue { get => 5; }

        public static IBasicBonus Spawn(List<IPoint> snakeBody)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                bool outsideOfScoreRange = x > 0 && y > 10;

                IBasicBonus dollar = new Dollar(x, y);

                if (!snakeBody.Any(x => x.Equals(dollar))
                    && outsideOfScoreRange)
                {
                    Writer.WriteAt(y, x, dollar.Symbol);

                    return dollar;
                }
            }
        }
    }
}
