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

        private List<ISpawnable> spawnables 
            = new List<ISpawnable>();

        private IPlayer _player;
        private bool _hasWalls;
        private int _snakeLength;

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
            Console.CursorVisible = false;

            Menu.StartingScreen();

            _snake = Factory.CreateSnake(_snakeLength);

            // First apple spawn
            spawnables.Add(FoodSpawner.Spawn("apple", _snake.Body));

            GameLoop();

            FileManager.SaveHighScore(_player, _scoreManager.Score);
            Menu.GameOverScreen(_scoreManager);
        }

        private void GameLoop()
        {
            // Timer for Dollar spawnable
            Timer timer = new Timer(TimerCallback, null, 0, 20000);

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

            timer.Dispose();
        }

        private void TimerCallback(object o)
        {
            spawnables.Add(FoodSpawner.Spawn("dollar", _snake.Body));
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

                if (OnSpawnable())
                {
                    ISpawnable spawnable = GetSpawnable();
                    spawnable.OnDevour(_snake, _scoreManager);
                    spawnables.Remove(spawnable);

                    if (spawnable is Apple)
                    {
                        spawnables.Add(FoodSpawner.Spawn("apple", _snake.Body));
                    }

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

        private bool OnSpawnable()
        {
            return spawnables.Any((s) => s.EqualsPosition(_snake.Head));
        }

        private ISpawnable GetSpawnable()
        {
            return spawnables.Find((s) => s.EqualsPosition(_snake.Head));
        }
    }
}
