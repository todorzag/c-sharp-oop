using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public abstract class ComplexBonus : Point, IComplexBonus
    {
        protected ComplexBonus(int x, int y) : base(x, y)
        {
        }

        public abstract string Symbol { get; }

        public abstract int ScoreValue { get; }

        public abstract void OnDevour(ISnake snake);
    }
}
