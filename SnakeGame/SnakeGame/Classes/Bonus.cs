using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    public class Bonus : Point, IBonus
    {
        private IOnConsume onConsumeInterface;

        public string Symbol { get; }

        public int ScoreValue { get; }

        public Bonus(
            int x,
            int y,
            string symbol,
            int scoreValue,
            IOnConsume onConsumeStrategy) 
            : base(x, y)
        {
            Symbol = symbol;
            ScoreValue = scoreValue;
            onConsumeInterface = onConsumeStrategy;
        }

        public void Consume(object obj)
        {
            onConsumeInterface.Consume(obj);
        }
    }
}
