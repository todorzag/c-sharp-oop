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

        private List<IBasicBonus> _basicBonuses =
            new List<IBasicBonus>();

        private List<IComplexBonus> _complexBonuses =
            new List<IComplexBonus>();

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
            _basicBonuses.Add(Apple.Spawn(_snake.Body));

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
            _basicBonuses.Add(Dollar.Spawn(_snake.Body));
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

                if (OnBasicBonus() || OnComplexBonus())
                {
                    IBasicBonus bonus = GetBonus();

                    _scoreManager.Add(bonus.ScoreValue);

                    if (OnBasicBonus())
                    {
                        BonusesEngine.BasicBonus(_basicBonuses, _scoreManager, _snake);
                    }
                    else if (OnComplexBonus())
                    {
                        BonusesEngine.ComplexBonus(_complexBonuses, _scoreManager, _snake);
                    }
                    

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

        // In Snake?
        private bool OnBasicBonus()
        {
            return _basicBonuses.Any((s) => s.EqualsPosition(_snake.Head));
        }

        private bool OnComplexBonus()
        {
            return _complexBonuses.Any((s) => s.EqualsPosition(_snake.Head));
        }

        private IBasicBonus GetBonus()
        {
            IBasicBonus bonus =
                _basicBonuses.Find((s) => s.EqualsPosition(_snake.Head));

            if (bonus == null)
            {
                bonus =
                    _complexBonuses.Find((s) => s.EqualsPosition(_snake.Head));
            }

            return bonus;
        }
    }
}
