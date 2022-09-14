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

        public bool HasEnded = false;

        private Dictionary<string, Directions> movementDirections 
            = new Dictionary<string, Directions>
            {
                {"RightArrow", Directions.Right },
                {"LeftArrow", Directions.Left },
                {"DownArrow", Directions.Down },
                {"UpArrow", Directions.Up }
            };

        private Snake _snake = new Snake(4);

        private string _user;
        private (int, int) _applePosition;
        private Directions _lastDirection;
        private string _keyPressed = "RightArrow";

        public Game() { }

        public void Start()
        {
            Console.CursorVisible = false;

            do
            {
                _snake.RenderSnake();

                Task game = Task.Run(() =>
                {
                    _keyPressed = Console.ReadKey(true).Key.ToString();
                });

                game.Wait(75);

                DirectionHandler(_keyPressed);
            }
            while (!HasEnded);
        }

        public void GetConfigData()
        {
            SetUserName();
            _snake.GameHasWalls = AskHasWalls();

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

        private void AppleHandler()
        {
            if (_snake.Head.OnApple(_applePosition))
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
            Directions direction;
            
            if (IsKeyInDictionary(keyPressed))
            {
                direction = movementDirections[keyPressed];
                _lastDirection = direction;
            }
            else
            {
                direction = _lastDirection;
            }

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

        private bool IsKeyInDictionary(string keyPressed)
        {
            return movementDirections.ContainsKey(keyPressed);
        }

        private void MoveSnake(int directionNum, Action<int> moveMethod)
        {
            _snake.UpdateBodyPosition();

            try
            {
                moveMethod(directionNum);
            }
            catch (Exception)
            {
                HasEnded = true;
            }


            AppleHandler();
        }

        
    }
}
