namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var game = new Game();

            game.GetConfigData();

            game.WaitForKeyPress();

            Console.Clear();

            game.SpawnApple();

            game.Start();

        }
    }
}