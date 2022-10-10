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
    public class Food : Point, IFood
    {
        private IOnConsume _onConsumeStrategy;
        private IOnRespawn _onRespawnStrategy;

        public Food(
             IOnConsume onConsumeStrategy,
             IOnRespawn onRespawnStrategy,
             string symbol,
             int timeDelay,
             int x = 0,
             int y = 0)
                 : base(x, y)
        {
            Symbol = symbol;
            TimeDelay = timeDelay;
            _onConsumeStrategy = onConsumeStrategy;
            _onRespawnStrategy = onRespawnStrategy;
        }

        public string Symbol { get; }
        public int TimeDelay { get; }

        public void PerformConsume(ISnake snake)
        {
            _onConsumeStrategy.PerformConsume(snake);
        }

        public void Render()
        {
            Writer.ConsoleWriteAt(Y, X, Symbol);
        }

        public void Respawn(IFood food)
        {
            _onRespawnStrategy.Respawn(food);
        }
    }
}
