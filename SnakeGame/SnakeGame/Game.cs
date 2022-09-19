using System.Security.Cryptography;

namespace SnakeGame
{
    public class Game
    {
        public bool SnakeIsAlive = true;

        private Snake _snake = new Snake(4);

        private string _user;
        private (int, int) _applePosition;
        private string _keyPressed;
        private bool _hasWalls;
        private Directions _direction = Directions.RightArrow;

        public Game() { }

        public void MainProcess()
        {
            Console.CursorVisible = false;

            OpenStartingMenu();
            // Close starting menu
            Console.Clear();

            StartingProcesses();

            GameLoop();

            if (!SnakeIsAlive)
            {
                GameOver();
            }
        }

        private void GameLoop()
        {
            while (SnakeIsAlive)
            {
                if (_keyPressed == "Escape")
                {
                    SnakeIsAlive = false;
                    break;
                }

                SetLegalDirection();

                DirectionHandler();
            }
        }

        private void StartingProcesses()
        {
            SpawnApple();
            _snake.Render();
        }

        private void OpenStartingMenu()
        {
            GetConfigData();
            WaitForKeyPress();
        }

        private void SetLegalDirection()
        {
            if (Enum.TryParse<Directions>(_keyPressed, out var legalDirection))
            {
                _direction = legalDirection;
            }
        }

        private void GetConfigData()
        {
            SetUserName();
            _hasWalls = AskHasWalls();
        }

        private void WaitForKeyPress()
        {
            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo);

            while (Console.KeyAvailable == false)
                Thread.Sleep(250);
        }

        private void SpawnApple()
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(1, Console.WindowHeight - 1);
                int y = random.Next(1, Console.WindowWidth - 1);

                _applePosition = (x, y);

                if (!_snake.CheckSpawnOnBody(_applePosition))
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
                _snake.AddPart();
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
            switch (_direction)
            {
                case Directions.RightArrow:
                    MoveSnake(1, _snake.MoveY);
                    break;

                case Directions.LeftArrow:
                    MoveSnake(-1, _snake.MoveY);
                    break;

                case Directions.DownArrow:
                    MoveSnake(1, _snake.MoveX);
                    break;

                case Directions.UpArrow:
                    MoveSnake(-1, _snake.MoveX);
                    break;

                default:
                    MoveSnake(1, _snake.MoveY);
                    break;
            }
        }

        private void MoveSnake(int directionNum, Action<int, bool> moveMethod)
        {
            while (Console.KeyAvailable == false)
            {
                _snake.UpdateBodyPosition();

                try
                {
                    moveMethod(directionNum, _hasWalls);
                }
                catch (Exception)
                {
                    SnakeIsAlive = false;
                    break;
                }

                AppleHandler();

                _snake.Render();

                Thread.Sleep(75);
            }

            if (SnakeIsAlive)
            {
                _keyPressed = Console.ReadKey(true).Key.ToString();
            }
        }
    }
}
