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
        public static void RenderStartingScreen()
        {
            RenderStartingLogo();
            WaitForKeyPress();
            Console.Clear();
        }

        public static void RenderGameOverScreen(int score)
        {
            Writer.WriteMessage(Logos.GameOverLogo);

            Writer.WriteMessage(Logos.ScoreWordLogo);
            Writer.WriteMessage(Logos.GenerateScoreLogo(score));
        }

        private static void RenderStartingLogo()
        {
            Console.Clear();
            Writer.WriteMessage(Logos.GameStartLogo);
        }

        private static void WaitForKeyPress()
        {
            while (Console.KeyAvailable == false)
                Thread.Sleep(250);
        }
    }
}
