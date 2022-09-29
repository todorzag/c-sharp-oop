using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class DollarStrategy : IOnConsume
    {
        public DollarStrategy()
        {
        }

        public string Symbol { get => "$"; }

        public int ScoreValue { get => 5; }

        public void Consume(object obj)
        {
            return;
        }
    }
}
