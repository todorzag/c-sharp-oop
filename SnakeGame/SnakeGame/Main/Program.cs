using SnakeGame.Classes;

namespace SnakeGame.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Thread thread = new Thread(() =>
            {
                var game = new Game();

                game.MainProcess();
            });

            thread.Start();
        }
    }
}