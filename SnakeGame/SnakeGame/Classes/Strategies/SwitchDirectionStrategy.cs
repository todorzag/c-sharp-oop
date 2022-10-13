using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    internal class SwitchDirectionStrategy : IConsumable
    {
        public void PerformConsume(ISnake snake, int scoreValue)
        {
            for (int i = 0; i < scoreValue; i++)
            {
                snake.AddPart();
            }

            snake.Body.Reverse();

            snake.Direction =
                SnakeMoveChecker.FindSafeDirection(snake.Body);
        }
    }
}
