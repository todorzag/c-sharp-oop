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
                    var game = Factory.CreateGame();

                    game.MainProcess();
                }
                catch (ArgumentOutOfRangeException)
                {
                    StandardMessagesWriter.InitalSnakeLengthError();
                }
                
            });

            thread.Start();
        }
    }
}