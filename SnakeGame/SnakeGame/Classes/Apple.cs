using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class Apple : Point, IBonus
    {
        public Apple(int x, int y) : base(x, y)
        {
        }

        public string Symbol { get => "@"; }

        public int ScoreValue { get => 1; }
    }
}
