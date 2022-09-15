﻿using System.Security.Cryptography;

namespace SnakeGame
{
    public class Game
    {
        private static List<string> _legalKeys =
            new List<string>
            {
            "RightArrow",
            "LeftArrow",
            "UpArrow",
            "DownArrow"
            };

        public bool HasEnded = false;

        private Snake _snake = new Snake(4);

        private string _user;
        private (int, int) _applePosition;
        private string _keyPressed;
        private string _lastPressed = "RightArrow";

        public Game() { }

        public void Start()
        {
            Console.CursorVisible = false;

            _snake.RenderSnake();

            do
            {
                Task keyLogger = Task.Run(() =>
                {
                    _keyPressed = Console.ReadKey(true).Key.ToString();
                });

                keyLogger.Wait(75);

                if (_keyPressed == "Escape")
                {
                    break;
                }

                SetLegalKeyPressed();

                DirectionHandler();
            }
            while (!HasEnded);

            GameOver();
        }

        private void SetLegalKeyPressed()
        {
            if (_legalKeys.Contains(_keyPressed))
            {
                _lastPressed = _keyPressed;
            }
            else
            {
                _keyPressed = _lastPressed;
            }
        }

        public void GetConfigData()
        {
            SetUserName();
            _snake.GameHasWalls = AskHasWalls();
        }

        public void WaitForKeyPress()
        {
            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo);

            while (Console.KeyAvailable == false)
                Thread.Sleep(250);
        }

        public void SpawnApple()
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                _applePosition = (x, y);

                if (!_snake.CheckSpawnOnSnake(_applePosition))
                {
                    Console.SetCursorPosition(y, x);
                    Console.Write("@");
                    break;
                }
            }
        }

        private void GameOver()
        {
            FileManager.SaveHighScore(_user, _snake.Score);

            Console.WriteLine(Logos.GameOverLogo);
            RenderScore();
        }

        private void AppleHandler()
        {
            if (_applePosition == _snake.Head.Position)
            {
                _snake.AddSnakePart();
                SpawnApple();
            }
        }

        private void SetUserName()
        {
            Console.Write("Please enter username:");
            _user = Console.ReadLine();
        }

        private void RenderScore()
        {
            Console.WriteLine(Logos.ScoreWordLogo);
            Console.WriteLine(Logos.GenerateScoreLogo(_snake.Score));
            Console.WriteLine();
        }

        private bool AskHasWalls()
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

        private void DirectionHandler()
        {
            switch (_keyPressed)
            {
                case "RightArrow":
                    MoveSnake(1, _snake.MoveY);
                    break;

                case "LeftArrow":
                    MoveSnake(-1, _snake.MoveY);
                    break;

                case "DownArrow":
                    MoveSnake(1, _snake.MoveX);
                    break;

                case "UpArrow":
                    MoveSnake(-1, _snake.MoveX);
                    break;
            }
        }

        private void MoveSnake(int directionNum, Action<int> moveMethod)
        {
            while (Console.KeyAvailable == false)
            {
                _snake.UpdateBodyPosition();

                try
                {
                    moveMethod(directionNum);
                }
                catch (Exception)
                {
                    HasEnded = true;
                    break;
                }

                AppleHandler();

                _snake.RenderSnake();

                Thread.Sleep(75);
            }
        }
    }
}
