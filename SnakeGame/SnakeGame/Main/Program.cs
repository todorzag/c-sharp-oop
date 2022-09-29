using SnakeGame.Classes;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Thread thread = new Thread(() =>
            {
                try
                {
                    IGameConfigCapturer gameConfigCapturer =
                        Factory.CreateGameConfigCapturer();

                    IGameConfig gameConfig =
                        gameConfigCapturer.GetDataFromInput();

                    IDiffilcultyHandler diffilcultyHandler =
                        Factory.CreateDiffilcultyHandler();

                    IBonusesHandler bonusesHandler =
                        Factory.GetBonusesHandler();

                    IScoreManager scoreManager =
                        Factory.CreateScoreManager();

                    ISnake snake =
                        Factory.CreateSnake(gameConfig.SnakeLength);

                    var game = Factory.CreateGame(
                        gameConfig,
                        diffilcultyHandler,
                        bonusesHandler,
                        scoreManager,
                        snake);

                    game.MainProcess();
                }
                catch (ArgumentOutOfRangeException)
                {
                    StandardMessages.SnakeLengthError();
                }
                
            });

            thread.Start();
        }
    }
}