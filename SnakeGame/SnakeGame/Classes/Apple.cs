using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class AppleStrategy : IOnConsume
    {
        public string Symbol { get => "@";}

        public int ScoreValue { get => 1;}

        public void Consume(object obj)
        {
            ISnake snake = (ISnake)obj;
            snake.AddPart();

            IBonusesHandler bonusesHandler = Factory.GetBonusesHandler();
            bonusesHandler.Add(Spawner.Spawn(snake.Body, new AppleStrategy()));
        }
    }
}
