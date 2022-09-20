using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    public class Game
    {
        public bool SnakeIsAlive = true;

        private Snake _snake;
        private IDiffilcultyHandler _diffilcultyHandler = new DiffilcultyHandler();
        private IScoreManager _scoreManager = new ScoreManager();

        private string _user;
        private int _snakeLength;
        private (int, int) _applePosition;
        private string _keyPressed;
        private bool _hasWalls;
        private Directions _direction = Directions.RightArrow;

        public Game() { }

        public void MainProcess()
        {
            Console.CursorVisible = false;

            OpenStartingMenu();

            GenerateSnake();

            // First apple spawn
            SpawnApple();

            GameLoop();

            FileManager.SaveHighScore(_user, _scoreManager.Score);
            GameOverScreen();
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

        private void OpenStartingMenu()
        {
            GetConfigData();
            PrintStartingLogo();
            WaitForKeyPress();
            Console.Clear();
        }

        private void GenerateSnake()
        {
            _snake = new Snake(_snakeLength);
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
            SetHasWalls();
            SetSnakeLength();
        }

        private void SetSnakeLength()
        {
            Console.WriteLine("How long would you like the snake to be?");
            Console.WriteLine("Minimum of 0, Maximum of 10");
            _snakeLength = int.Parse(Console.ReadLine());

            if (_snakeLength < 0 || _snakeLength > 10)
            {
                throw new ArgumentOutOfRangeException
                    ("Snake length must be greater than 0 and lesser than 10");
            };
        }

        private void WaitForKeyPress()
        {
            while (Console.KeyAvailable == false)
                Thread.Sleep(250);
        }

        private static void PrintStartingLogo()
        {
            Console.Clear();
            Console.WriteLine(Logos.GameStartLogo);
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

        private void GameOverScreen()
        {
            Console.WriteLine(Logos.GameOverLogo);
            _scoreManager.RenderLogo();
        }

        private bool IsOnApple()
        {
            return _applePosition == _snake.Head.Position;
        }

        private void SetUserName()
        {
            Console.Write("Please enter username:");
            _user = Console.ReadLine();
        }

        private void SetHasWalls()
        {
            Console.WriteLine("Would you like the board to have walls?");
            string answer = Console.ReadLine();
            _hasWalls = false;

            if (answer == "Y")
            {
                _hasWalls = true;
            }
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
            }
        }

        private void MoveSnake(int directionNum, Action<int, bool> moveMethod)
        {
            while (Console.KeyAvailable == false)
            {
                _scoreManager.Render();

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

                if (IsOnApple())
                {
                    _snake.AddPart();
                    _scoreManager.Add(1);
                    SpawnApple();

                    _diffilcultyHandler.CheckToRaiseLevel(_scoreManager.Score);
                }

                _snake.Render();

                Thread.Sleep(_diffilcultyHandler.Miliseconds);
            }

            if (SnakeIsAlive)
            {
                _keyPressed = Console.ReadKey(true).Key.ToString();
            }
        }
    }
}
