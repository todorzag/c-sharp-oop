using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    public class Game : IGame
    {
        public bool SnakeIsAlive = true;

        private ISnake _snake;

        private IScoreManager _scoreManager
            = Factory.CreateScoreManager();

        private IDiffilcultyHandler _diffilcultyHandler
            = Factory.CreateDiffilcultyHandler();

        private IPlayer _player;
        private bool _hasWalls;
        private int _snakeLength;

        private IPoint _apple;
        private string _keyPressed;
        private Directions _direction = Directions.RightArrow;

        public Game(IPlayer player, bool hasWalls, int snakeLength)
        {
            _player = player;
            _hasWalls = hasWalls;
            _snakeLength = snakeLength;
        }

        public void MainProcess()
        {
            Console.CursorVisible = false; ;

            Menu.StartingScreen();

            _snake = Factory.CreateSnake(_snakeLength);

            // First apple spawn
            _apple = FoodSpawner.SpawnApple(_snake.Body);

            GameLoop();

            FileManager.SaveHighScore(_player, _scoreManager.Score);
            Menu.GameOverScreen(_scoreManager);
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

        private void SetLegalDirection()
        {
            if (Enum.TryParse<Directions>(_keyPressed, out var legalDirection))
            {
                _direction = legalDirection;
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

                if (_apple.Equals(_snake.Head))
                {
                    _snake.AddPart();
                    _scoreManager.Add(1);

                    _apple = FoodSpawner.SpawnApple(_snake.Body);

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
