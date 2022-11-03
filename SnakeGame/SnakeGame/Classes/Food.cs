using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame.Classes
{
    public class Food : Point, IFood, IRenderable
    {
        private IConsumable _onConsumeStrategy;

        public Food(
             IConsumable onConsumeStrategy,
             string symbol,
             int scoreValue,
             int x = 0,
             int y = 0)
                 : base(x, y)
        {
            Symbol = symbol;
            ScoreValue = scoreValue;
            _onConsumeStrategy = onConsumeStrategy;
        }

        public string Symbol { get; }
        public int ScoreValue { get; }

        public void PerformConsume(ISnake snake, int scoreValue)
        {
            _onConsumeStrategy.PerformConsume(snake, scoreValue);
        }

        public void Render()
        {
            Writer.ConsoleWriteAt(Y, X, Symbol);
        }
    }
}
