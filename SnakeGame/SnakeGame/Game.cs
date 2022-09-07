namespace SnakeGame
{
    public class Game
    {
        enum Directions
        {
            Right,
            Left,
            Up,
            Down
        }

        public delegate void Del();

        public bool SnakeIsAlive = true;

        private Snake _snake = new Snake();
        private Dictionary<string, Directions> movementDirections;

        private int _consoleHeight = Console.WindowHeight;
        private int _consoleWidth = Console.WindowWidth;

        private string _user;
        private bool _hasWalls;
        private (int, int) _applePosition;
        private string _keyPressed = "RightArrow";

        public Game() { }

        public void Start()
        {
            Console.CursorVisible = false;
            PopulateDirections();

            do
            {
                _snake.RenderSnake();

                Task game = Task.Run(() =>
                {
                    _keyPressed = Console.ReadKey().Key.ToString();
                });

                game.Wait(75);

                DirectionHandler(_keyPressed);
            }
            while (SnakeIsAlive);
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

        private void PopulateDirections()
        {
            movementDirections = new Dictionary<string, Directions>
            {
                {"RightArrow", Directions.Right },
                {"LeftArrow", Directions.Left },
                {"DownArrow", Directions.Down },
                {"UpArrow", Directions.Up }
            };
        }

        private bool ShouldEndGame()
        {
            bool result = false;

            bool isOutOfBounds = _snake.CheckIfOutOfBounds(_consoleHeight, _consoleWidth);
            bool hitItself = _snake.CheckIfHitItself();

            if (isOutOfBounds)
            {
                if (_hasWalls)
                {
                    result = true;
                }
            }
            else if (hitItself)
            {
                result =  true;
            }

            return result;
        }

        private bool ShouldTeleport()
        {
            bool result = false;

            bool isOutOfBounds = _snake.CheckIfOutOfBounds(_consoleHeight, _consoleWidth);

            if (isOutOfBounds)
            {
                if (!_hasWalls)
                {
                    result = true;
                }
            }

            return result;
        }

        private void AppleHandler()
        {
            if (_snake.SnakeHead.OnApple(_applePosition))
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

        private void DirectionHandler(string keyPressed)
        {
            // Check if key is in Dict
            var direction = movementDirections[keyPressed];

            switch (direction)
            {
                case Directions.Right:
                    MoveSnake(1, _snake.MoveY);
                    break;

                case Directions.Left:
                    MoveSnake(-1, _snake.MoveY);
                    break;

                case Directions.Down:
                    MoveSnake(1, _snake.MoveX);
                    break;

                case Directions.Up:
                    MoveSnake(-1, _snake.MoveX);
                    break;
            }
        }

        private void MoveSnake(int directionNum, Action<int> moveMethod)
        {
            _snake.ClearLastSnakePart();
            _snake.UpdateBodyPosition();

            moveMethod(directionNum);

            if (ShouldEndGame())
            {
                SnakeIsAlive = false;
            }

            if (ShouldTeleport())
            {
                _snake.Teleport(_consoleHeight, _consoleWidth);
            }

            AppleHandler();
        }

        
    }
}
