using SnakeGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IConsumable
    {
        void PerformConsume(ISnake snake, int scoreValue);
    }
}
