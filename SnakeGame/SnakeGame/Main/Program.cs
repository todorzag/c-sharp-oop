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

                    var game = Factory.CreateGame(gameConfig);

                    game.MainProcess();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    StandardMessages.Error(e);
                }
                
            });

            thread.Start();
        }
    }
}