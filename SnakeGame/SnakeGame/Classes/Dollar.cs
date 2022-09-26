using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class Dollar : Point, ISpawnable
    {
        public Dollar(int x, int y) : base(x, y)
        {
        }

        public void OnDevour(ISnake snake, IScoreManager scoreManager)
        {
            scoreManager.Add(5);
        }

        public void Render()
        {
            Writer.WriteAt(Y, X, "$");
        }
    }
}
