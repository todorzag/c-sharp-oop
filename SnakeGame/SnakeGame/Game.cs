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
        private Snake _snake = new Snake();

        private bool _hasWalls;
        private string _user;
        private string _keyPressed = "RightArrow";
        private (int, int) _applePosition;

        public Game() { }

        public void Start()
        {
            Console.CursorVisible = false;

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
        }

        public void GetConfigData()
        {
            SetUserName();
            _hasWalls = AskHasWalls();

            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo);
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

        public void Over()
        {
            FileManager.SaveHighScore(_user, _snake.Score);

            Console.WriteLine(Logos.GameOverLogo);
            RenderScore();
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
            if (_snake.OnApple(_applePosition))
            {
                _snake.EatApple();
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
