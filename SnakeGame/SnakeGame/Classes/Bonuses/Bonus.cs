using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Bonuses
{
    public abstract class Bonus : Point, IBonus
    {
        private Action<object> _onConsumeStrategy;

        protected Bonus(
             Action<object> onConsumeStrategy,
             int x = 0,
             int y = 0)
                 : base(x, y)
        {
            _onConsumeStrategy = onConsumeStrategy;
        }

        public abstract string Symbol { get; }

        public abstract int ScoreValue { get; }

        public void PerformConsume(object obj)
        {
            _onConsumeStrategy(obj);
        }

        public void Render()
        {
            Writer.WriteAt(Y, X, Symbol);
        }
    }
}
