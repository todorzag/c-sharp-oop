using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    public class AddSnakePartStrategy : IConsumable
    {
        public void PerformConsume(object obj)
        {
            ISnake snake = (ISnake)obj;
            snake.AddPart();

            RespawnBonus(snake);
        }

        private static void RespawnBonus(ISnake snake)
        {
            IBonusesHandler handler = Factory.GetBonusesHandler();

            handler.Add(
                Spawner.Spawn(
                    snake.Body, Factory.CreateApple()
                    ));
        }
    }
}
