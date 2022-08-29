using System.Xml.Linq;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SnakeGame
{
    internal class Program
    {
        public static GameBoard gameBoard = new GameBoard(10, 10);
        public static AppleSpawner appleSpawner = new AppleSpawner();
        public static Snake snake = new Snake();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            string keyPressed = "RightArrow";

            do
            {
                RenderGame();

                if (CheckEndGame())
                    break;

                Task game = Task.Run(() =>
                {
                    keyPressed = Console.ReadKey().Key.ToString();
                });

                game.Wait(250);

                MakeMove(keyPressed);

                if (appleSpawner.isEaten)
                    appleSpawner.SpawnApple(gameBoard.Board);
            }
            while (true);
        }

        private static bool CheckEndGame()
        {
            bool isOutOfBounds = snake.ChexkIfOutOfBounds(gameBoard.Board);
            bool hitItself = snake.CheckIfHitItself();

            return isOutOfBounds || hitItself;
        }

        private static void MakeMove(string keyPressed)
        {
            snake.ClearLastSnakePart(gameBoard.Board);
            snake.Turn(keyPressed);

            if (snake.OnApple(gameBoard.Board))
            {
                EatApple();
            }
        }

        private static void RenderGame()
        {
            Console.Clear();

            snake.RenderSnake(gameBoard.Board);
            gameBoard.RenderBoard();
        }

        private static void EatApple()
        {
            snake.AddSnakePart();
            appleSpawner.isEaten = true;
        }
    }
}