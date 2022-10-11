using SnakeGame.Constants;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class ScreenRenderer
    {
        public static void StartingScreen()
        {
            PrintStartingLogo();
            WaitForKeyPress();
            Console.Clear();
        }

        public static void GameOverScreen(IScoreManager scoreManager)
        {
            Console.WriteLine(Logos.GameOverLogo);

            Console.WriteLine(Logos.ScoreWordLogo);
            Console.WriteLine(Logos.GenerateScoreLogo(scoreManager.CurrentScore));
            Console.WriteLine();
        }

        private static void PrintStartingLogo()
        {
            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo);
        }

        private static void WaitForKeyPress()
        {
            while (Console.KeyAvailable == false)
                Thread.Sleep(250);
        }
    }
}
