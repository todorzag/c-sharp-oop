using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    public class Food : Point, IFood
    {
        private IStrategy _onConsumeStrategy;

        public Food(
             IStrategy onConsumeStrategy,
             string symbol,
             int x = 0,
             int y = 0)
                 : base(x, y)
        {
            Symbol = symbol;
            _onConsumeStrategy = onConsumeStrategy;
        }

        public string Symbol { get; }

        public void PerformConsume(ISnake snake)
        {
            _onConsumeStrategy.PerformConsume(snake);
        }

        public void Render()
        {
            Writer.ConsoleWriteAt(Y, X, Symbol);
        }
    }
}
