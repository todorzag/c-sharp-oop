using SnakeGame.Classes;
using SnakeGame.Classes.Bonuses;
using SnakeGame.Classes.Strategies;
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
        public static IGame CreateGame()
        {

            IGameConfigCapturer gameConfigCapturer = CreateGameConfigCapturer();

            IGameConfig gameConfig = gameConfigCapturer.GetDataFromInput();

            IDiffilcultyHandler diffilcultyHandler = CreateDiffilcultyHandler();

            IBonusesHandler bonusesHandler = GetBonusesHandler();

            IScoreManager scoreManager = CreateScoreManager();

            ISnake snake = CreateSnake(gameConfig.InitalSnakeLength);

            return new Game(gameConfig, diffilcultyHandler, bonusesHandler, scoreManager, snake);
        }

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

        public static IGameConfig CreateGameConfig(IPlayer player, bool hasWalls, int initialSnakeLength)
        {
            return new GameConfig(player, hasWalls, initialSnakeLength);
        }

        public static IGameConfigCapturer CreateGameConfigCapturer()
        {
            return new GameConfigCapturer();
        }

        public static IPoint CreatePoint(int x, int y)
        {
            return new Point(x, y);
        }

        public static IBonusesHandler GetBonusesHandler()
        {
            return BonusesHandler.Instance;
        }

        public static IBonus CreateDollar()
        {
            return new Dollar(new DoNothingStrategy());
        }

        public static IBonus CreateApple()
        {
            return new Apple(new AddSnakePartStrategy());
        }

        internal static IBonus CreateCross()
        {
            return new Cross(new DoNothingStrategy());
        }
    }
}
