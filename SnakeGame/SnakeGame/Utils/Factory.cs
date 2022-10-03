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
    public class Factory
    {
        public static IGame CreateGame()
        {

            IGameConfigCapturer gameConfigCapturer = CreateGameConfigCapturer();

            gameConfigCapturer.GetDataFromInput();

            IDiffilcultyHandler diffilcultyHandler = CreateDiffilcultyHandler();

            IBonusesHandler bonusesHandler = GetBonusesHandler();

            IScoreManager scoreManager = CreateScoreManager();

            ISnake snake = CreateSnake(GameConfig.InitalSnakeLength);

            return new Game(diffilcultyHandler, bonusesHandler, scoreManager, snake);
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
            return new Dollar(Strategey.DoNothingStrategy);
        }

        public static IBonus CreateApple()
        {
            return new Apple(Strategey.AddSnakePartStrategy);
        }

        internal static IBonus CreateCross()
        {
            return new Cross(Strategey.DoNothingStrategy);
        }
    }
}
