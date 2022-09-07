namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var game = new Game();

            game.GetConfigData();

            Thread.Sleep(2000);
            Console.Clear();

            game.SpawnApple();

            game.Start();

            if (!game.SnakeIsAlive)
            {
                game.Over();
            }     
        }
    }
}