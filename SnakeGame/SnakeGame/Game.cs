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
        private AppleSpawner _appleSpawner = new AppleSpawner();
        private Snake _snake = new Snake();
        private GameBoard _gameBoard;

        private string _user;
        private string _keyPressed = "RightArrow";

        public Game() { }

        public void Start()
        {
            GameBeginning();
            Console.Clear();

            // Spawn first apple
            _appleSpawner.SpawnApple(_gameBoard.Board);

            do
            {
                RenderGame();

                Task game = Task.Run(() =>
                {
                    _keyPressed = Console.ReadKey().Key.ToString();
                });

                game.Wait(150);

                MakeMove(_keyPressed);

                OutOfBoundsHandler();
                HitItselfHandler();

                if (!_snake.isAlive)
                    break;

                AppleHandler();

                Console.Clear();
            }
            while (true);

            GameOver();
        }

        private void HitItselfHandler()
        {
            _snake.isAlive = !_snake.CheckIfHitItself();
        }

        private void OutOfBoundsHandler()
        {
            bool isOutOfBounds = _snake.CheckIfOutOfBounds(_gameBoard.Board);

            if (isOutOfBounds)
            {
                if (_gameBoard.Walls)
                {
                    _snake.isAlive = false;
                }
                else
                {
                    _snake.Teleport(_gameBoard.Board);
                }
            }
        }

        private void AppleHandler()
        {
            if (_snake.OnApple(_gameBoard.Board))
            {
                _snake.EatApple();
                _appleSpawner.SpawnApple(_gameBoard.Board);
            } 
        }

        private void GameBeginning()
        {
            bool hasWalls = AskHasWalls();
            _gameBoard = new GameBoard(hasWalls);

            SetUserName();

            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo);

            Thread.Sleep(2000);
        }

        private void SetUserName()
        {
            Console.Write("Please enter username:");
            _user = Console.ReadLine();
        }

        private void GameOver()
        {
            FileManager.SaveHighScore(_user, _snake.Score);

            Console.WriteLine(Logos.GameOverLogo);
            RenderScore();
        }

        private void RenderScore()
        {
            Console.WriteLine(Logos.ScoreWordLogo);
            Console.WriteLine(Logos.GenerateScoreLogo(_snake.Score));
            Console.WriteLine();
        }

        private static bool AskHasWalls()
        {
            Console.WriteLine("Would you like the board to have walls?");
            bool hasWalls = Console.ReadLine() == "Y";

            return hasWalls;
        }

        private void MakeMove(string keyPressed)
        {
            _snake.ClearLastSnakePart(_gameBoard.Board);
            _snake.Turn(keyPressed);
        }

        private void RenderGame()
        {
            _snake.RenderSnake(_gameBoard.Board);
            _gameBoard.RenderBoard();
        }
    }
}
