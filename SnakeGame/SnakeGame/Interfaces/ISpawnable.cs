using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    interface ISpawnable : IPoint
    {
        public void Render();

        public void OnDevour(ISnake snake, IScoreManager scoreManager);
    }
}
