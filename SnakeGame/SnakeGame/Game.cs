using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    public class Game
    {
        private static Game _instance = new Game();

        private AppleSpawner _appleSpawner = new AppleSpawner();
        private Snake _snake = new Snake();
        private GameBoard _gameBoard;

        private string _keyPressed = "RightArrow";

        public static Game GetInstance()
        {
            if (_instance == null)
                _instance = new Game();

            return _instance;
        }

        private Game() { }

        public void Start()
        {
            GameBeginning();

            Console.Clear();
            do
            {
                RenderScore();
                RenderGame();

                if (CheckEndGame())
                    break;

                Task game = Task.Run(() =>
                {
                    _keyPressed = Console.ReadKey().Key.ToString();
                });

                game.Wait(250);

                MakeMove(_keyPressed);

                if (_appleSpawner.isEaten)
                    _appleSpawner.SpawnApple(_gameBoard.Board);

                Console.Clear();
            }
            while (true);

            GameEnd();
        }

        private void GameBeginning()
        {
            (int x, int y) = GetBoardSize();
            _gameBoard = new GameBoard(x, y);

            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo); 
            Thread.Sleep(2000);
        }

        private void GameEnd()
        {
            Console.WriteLine(Logos.GameEndLogo);
        }

        private void RenderScore()
        {
            int score = CalculateScore();

            Console.WriteLine(Logos.ScoreWordLogo);
            Console.WriteLine(Logos.GenerateScoreLogo(score));
        }

        // - 3 because Snake starts with 3 parts
        private int CalculateScore()
            => (_snake.SnakeParts - 3);

        private (int, int) GetBoardSize()
        {
            Console.WriteLine("Please enter board size:");

            Console.Write("Height:");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Width:");
            int y = int.Parse(Console.ReadLine());

            return (x, y);
        }

        private bool CheckEndGame()
        {
            bool isOutOfBounds = _snake.ChexkIfOutOfBounds(_gameBoard.Board);
            bool hitItself = _snake.CheckIfHitItself();

            return isOutOfBounds || hitItself;
        }

        private void MakeMove(string keyPressed)
        {
            _snake.ClearLastSnakePart(_gameBoard.Board);
            _snake.Turn(keyPressed);

            if (_snake.OnApple(_gameBoard.Board))
            {
                EatApple();
            }
        }

        private void RenderGame()
        {
            _snake.RenderSnake(_gameBoard.Board);
            _gameBoard.RenderBoard();
        }

        private void EatApple()
        {
            _snake.AddSnakePart();
            _appleSpawner.isEaten = true;
        }
    }
}
