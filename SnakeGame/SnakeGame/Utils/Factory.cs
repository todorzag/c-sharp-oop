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

        public static IGameConfig CreateGameConfig(IPlayer player, bool hasWalls, int snakeLength)
        {
            return new GameConfig(player, hasWalls, snakeLength);
        }

        public static IGameConfigCapturer CreateGameConfigCapturer()
        {
            return new GameConfigCapturer();
        }

        public static IGame CreateGame(IGameConfig gameConfig)
        {
            return new Game(gameConfig);
        }

        public static IPoint CreatePoint(int x, int y)
        {
            return new Point(x, y);
        }

        public static IBonus CreateApple(int x, int y)
        {
            return new Apple(x, y);
        }

        public static IBonus CreateDollar(int x, int y)
        {
            return new Dollar(x, y);
        }
    }
}
