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

        public void Set(
            List<IPoint> snakeBody,
            IDiffilcultyHandler diffilcultyHandler)
        {
            PreviousScore = CurrentScore;
            CurrentScore = (snakeBody.Count - 1) - GameConfig.InitalSnakeLength;
            diffilcultyHandler.CheckToDecreaseLevel(CurrentScore, PreviousScore);
        }

        public void Render()
        {
            Writer.ConsoleWriteAt(0, 0, $"Score: {CurrentScore} ");
        }

        public void CheckScoreUnderZero(ISnake snake)
        {
            if (CurrentScore < 0)
            {
                snake.IsAlive = false;
            }
        }
    }
}
