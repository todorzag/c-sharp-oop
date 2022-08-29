using System.Xml.Linq;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SnakeGame
{
    internal class Program
    {
        public static GameBoard gameBoard = new GameBoard(20, 20);
        public static Snake snake = new Snake();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            snake.RenderSnake(gameBoard.Board);
            gameBoard.RenderBoard();

            string keyPressed = String.Empty;
            string lastPressed = "RightArrow";

            while (true)
            {
                Task game = Task.Run(() => {
                    keyPressed = Console.ReadKey().Key.ToString();
                    lastPressed = keyPressed;
                });

                if (!game.Wait(500))
                {
                    keyPressed = lastPressed;
                }

                Console.Clear();

                snake.ClearSnakePart(gameBoard.Board);
                snake.Turn(keyPressed);
                snake.RenderSnake(gameBoard.Board);

                gameBoard.RenderBoard();

                bool isOutOfBounds = snake.IsOutOfBounds(gameBoard.Board);
                bool hitItself = snake.HitItself();

                if (isOutOfBounds || hitItself)
                {
                    break;
                }
            }

        }
    }
}