﻿using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    internal class RemoveSnakePartStrategy : IOnConsume
    {
        public void PerformConsume(ISnake snake)
        {
            snake.RemovePart();
        }
    }
}
