using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    public class Game : IGame
    {
        public bool snakeIsAlive = true;

        private IScoreManager _scoreManager =
            Factory.CreateScoreManager();

        private IDiffilcultyHandler _diffilcultyHandler =
            Factory.CreateDiffilcultyHandler();

        private List<IBonus> _bonuses =
            new List<IBonus>();

        private ISnake _snake;
        private IGameConfig _config;

        private string _keyPressed;
        private Directions _direction = Directions.RightArrow;

        public Game(IGameConfig gameConfig)
        {
            _config = gameConfig;
        }

        public void MainProcess()
        {
            Console.CursorVisible = false;

            Menu.StartingScreen();

            _snake = Factory.CreateSnake(_config.SnakeLength);

            // First apple spawn
            _bonuses.Add(Spawner.SpawnApple(_snake.Body));

            GameLoop();

            FileManager.SaveHighScore(_config.Player, _scoreManager.Score);
            Menu.GameOverScreen(_scoreManager);
        }

        private void GameLoop()
        {
            // Timer for Dollar spawnable
            Timer timer = new(TimerCallback, null, 0, 20000);

            while (snakeIsAlive)
            {
                if (_keyPressed == "Escape")
                {
                    snakeIsAlive = false;
                    break;
                }

                SetLegalDirection();

                OnAction();
            }

            timer.Dispose();
        }

        private void TimerCallback(object o)
        {
            _bonuses.Add(Spawner.SpawnDollar( _snake.Body));
        }

        private void SetLegalDirection()
        {
            if (Enum.TryParse<Directions>(_keyPressed, out var legalDirection))
            {
                _direction = legalDirection;
            }
        }

        // Move to Snake
        private void OnAction()
        {
            while (Console.KeyAvailable == false)
            {
                _scoreManager.Render();

                _snake.UpdateBodyPosition();

                try
                {
                    _snake.Move(_direction, _config.HasWalls);
                }
                catch (GameEndException)
                {
                    snakeIsAlive = false;
                    break;
                }

                if (OnBonus())
                {
                    SpawnablesHandler();

                    _diffilcultyHandler.CheckToRaiseLevel(_scoreManager.Score);
                }

                _snake.Render();

                Thread.Sleep(_diffilcultyHandler.Miliseconds);
            }

            if (snakeIsAlive)
            {
                _keyPressed = Console.ReadKey(true).Key.ToString();
            }
        }

        private void SpawnablesHandler()
        {
            IBonus bonus =
                _bonuses.Find((s) => s.EqualsPosition(_snake.Head));

            _bonuses.Remove(bonus);

            // Interfaces for add snake and and score (different type bonus)
            // checker for max length
            // add for maximum length width * heigth

            if (bonus is Apple)
            {
                _snake.AddPart();
                _scoreManager.Add(1);

                _bonuses.Add(Spawner.SpawnApple(_snake.Body));
            }
            else if (bonus is Dollar)
            {
                _scoreManager.Add(5);
            }
        }

        // In Snake?
        private bool OnBonus()
        {
            return _bonuses.Any((s) => s.EqualsPosition(_snake.Head));
        }
    }
}
