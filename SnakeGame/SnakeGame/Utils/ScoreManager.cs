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
        private int _score = 0;

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public void Add(int n)
        {
            Score += n;
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Score: {Score}");
        }

        public void RenderLogo()
        {
            Console.WriteLine(Logos.ScoreWordLogo);
            Console.WriteLine(Logos.GenerateScoreLogo(Score));
            Console.WriteLine();
        }
    }
}
