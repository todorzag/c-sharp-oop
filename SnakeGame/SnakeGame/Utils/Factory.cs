using SnakeGame.Classes;
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

            IDiffilcultyHandler diffilcultyHandler = GetDiffilcultyHandler();

            IFoodHandler foodHandler = GetFoodHandler();

            IScoreManager scoreManager = CreateScoreManager();

            ISnake snake = CreateSnake(GameConfig.InitalSnakeLength);

            return new Game(diffilcultyHandler, foodHandler, scoreManager, snake);
        }

        public static IDiffilcultyHandler GetDiffilcultyHandler()
        {
            return DiffilcultyHandler.Instance;
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

        public static IFoodHandler GetFoodHandler()
        {
            return FoodHandler.Instance;
        }

        public static IFood CreateApple()
        {
            return new Food(
                AddSnakePartStrategy.GetStrategy, "@", 1);
        }

        public static IFood CreateSwitch()
        {
            return new Food(
               SwitchDirectionStrategy.GetStrategy, "&", 2);
        }

        public static IFood CreateCross()
        {
            return new Food(
                RemoveSnakePartStrategy.GetStrategy, "X", 10);
        }

        public static IFood CreateDiamond()
        {
            return new Food(
                DiscoModeStrategy.GetStrategy, "◆", 0);
        }
    }
}
