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
        public int CurrentScore { get; set; }
        public int PreviousScore { get; set; }

        public ScoreManager()
        {
        }

        public void Set(List<IPoint> snakeBody)
        {
            CurrentScore = (snakeBody.Count - 1) - GameConfig.InitalSnakeLength;
        }

        public void Render()
        {
            Writer.ConsoleWriteAt(0, 0, $"Score: {CurrentScore} ");
        }
    }
}
