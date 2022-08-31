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

        private bool _hasWalls;
        private string _user;
        private string _keyPressed = "RightArrow";

        public Game() { }

        public void Start()
        {
            GameStart();
            Console.Clear();

            // Spawn first apple
            _appleSpawner.SpawnApple(_snake);

            do
            {
                _snake.RenderSnake();

                Task game = Task.Run(() =>
                {
                    _keyPressed = Console.ReadKey().Key.ToString();
                });

                game.Wait(75);

                MakeMove(_keyPressed);

                if (EndGame())
                    break;

                AppleHandler();
            }
            while (true);

            GameOver();
        }

        private bool EndGame()
        {
            bool result = false;

            bool isOutOfBounds = _snake.CheckIfOutOfBounds();
            bool hitItself = _snake.CheckIfHitItself();

            if (isOutOfBounds)
            {
                if (_hasWalls)
                {
                    result = true;
                }
                else
                {
                    _snake.Teleport();
                }
            }
            else if (hitItself)
            {
                result =  true;
            }

            return result;
        }

        private void AppleHandler()
        {
            if (_snake.OnApple(_appleSpawner))
            {
                _snake.EatApple();
                _appleSpawner.SpawnApple(_snake);
            } 
        }

        private void GameStart()
        {
            SetUserName();
            _hasWalls = AskHasWalls();

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
            bool hasWalls = false;
            string answer = Console.ReadLine();

            if (answer == "Y")
            {
                hasWalls = true;
            }

            return hasWalls;
        }

        private void MakeMove(string keyPressed)
        {
            _snake.ClearLastSnakePart();
            _snake.Turn(keyPressed);
        }
    }
}
