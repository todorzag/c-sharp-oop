using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    public class DoNothingStrategy : IConsumable
    {
        public void PerformConsume(object obj)
        {
            return;
        }
    }
}
