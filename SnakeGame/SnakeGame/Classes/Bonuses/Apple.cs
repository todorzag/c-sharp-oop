using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Bonuses
{
    public class Apple : Bonus
    {
        public Apple(
            IConsumable onConsumeStrategy,
            int x = 0,
            int y = 0)
                : base(onConsumeStrategy, x, y)
        {
        }

        public override string Symbol => "@";

        public override int ScoreValue => 1; 
    }
}
