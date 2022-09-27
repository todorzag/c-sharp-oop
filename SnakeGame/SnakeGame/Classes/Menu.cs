using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class Menu
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
            scoreManager.RenderLogo();
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
