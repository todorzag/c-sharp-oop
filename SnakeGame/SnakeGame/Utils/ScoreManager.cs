using SnakeGame.Constants;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class ScoreManager : IScoreManager
    {
        public int Score { get; set; }

        public ScoreManager()
        {
        }

        public void Set(List<IPoint> snakeBody)
        {
            Score = (snakeBody.Count - 1) - GameConfig.InitalSnakeLength;
        }

        public void Render()
        {
            Writer.ConsoleWriteAt(0, 0, $"Score: {Score} ");
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
