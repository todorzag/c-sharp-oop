using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    public class AddSnakePartStrategy : IStrategy
    {
        public void PerformConsume(ISnake snake)
        {
            snake.AddPart();
        }
    }
}
