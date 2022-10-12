﻿using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    internal class RemoveSnakePartStrategy : IConsumable
    {
        public void PerformConsume(ISnake snake, int scoreValue)
        {
            for (int i = 0; i < scoreValue; i++)
            {
                snake.RemoveTail();
            }
        }
    }
}
