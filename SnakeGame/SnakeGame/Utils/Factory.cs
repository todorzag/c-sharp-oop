using SnakeGame.Classes;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class Factory
    {
        public static IDiffilcultyHandler CreateDiffilcultyHandler()
        {
            return new DiffilcultyHandler();
        }

        public static IScoreManager CreateScoreManager()
        {
            return new ScoreManager();
        }

        public static IPlayer CreatePlayer(string firstName, string lastName)
        {
            return new Player(firstName, lastName);
        }

        public static ISnake CreateSnake(int length)
        {
            return new Snake(length);
        }

        public static IGameConfig CreateGameConfig()
        {
            return new GameConfigCapturer();
        }

        public static IGame CreateGame(IPlayer player, bool hasWalls, int snakeLength)
        {
            return new Game(player, hasWalls, snakeLength);
        }

        public static IPoint CreatePoint(int x, int y)
        {
            return new Point(x, y);
        }

        public static ISpawnable CreateApple(int x, int y)
        {
            return new Apple(x, y);
        }

        public static ISpawnable CreateDollar(int x, int y)
        {
            return new Dollar(x, y);
        }
    }
}
