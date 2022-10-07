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
    internal class SwitchDirectionStrategy : IStrategy
    {
        public void PerformConsume(ISnake snake)
        {
            snake.AddPart();
            snake.AddPart();

            snake.Body.Reverse();

            switch (snake.Direction)
            {
                case Directions.RightArrow:
                    snake.Direction = Directions.LeftArrow;
                    break;

                case Directions.LeftArrow:
                    snake.Direction = Directions.RightArrow;
                    break;

                case Directions.DownArrow:
                    snake.Direction = Directions.UpArrow;
                    break;

                case Directions.UpArrow:
                    snake.Direction = Directions.DownArrow;
                    break;
            }
        }
    }
}
