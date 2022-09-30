using SnakeGame.Constants;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class ScoreManager : IScoreManager, IRenderable
    {
        public int Score { get; set; } = 0;

        public ScoreManager()
        {
        }

        public void Add(int n)
        {
            Score += n;
        }

        public void Render()
        {
            Writer.WriteAt(0, 0, $"Score: {Score}");
        }

        public void CheckScoreUnderZero()
        {
            if (Score < 0)
            {
                throw new GameEndException();
            }
        }
    }
}
