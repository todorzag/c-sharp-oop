using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class Apple : Point, ISpawnable
    {
        public Apple(int x, int y) : base(x, y)
        {
        }

        public void OnDevour(ISnake snake, IScoreManager scoreManager)
        {
            snake.AddPart();
            scoreManager.Add(1);
        }

        public void Render()
        {
            Writer.WriteAt(Y, X, "@");
        }

    }
}
