using SnakeGame.Classes.Bonuses;
using SnakeGame.Classes.Strategies;
using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Classes
{
    public class Game : IGame
    {
        public bool snakeIsAlive = true;

        private IScoreManager _scoreManager;
        private IDiffilcultyHandler _diffilcultyHandler;
        private IBonusesHandler _bonusesHandler;
        private ISnake _snake;

        private List<Timer> _timers = new List<Timer>();

        private string _keyPressed;
        private Directions _direction = Directions.RightArrow;

        public Game(
            IDiffilcultyHandler diffilcultyHandler,
            IBonusesHandler bonusesHandler,
            IScoreManager scoreManager,
            ISnake snake)
        {
            _diffilcultyHandler = diffilcultyHandler;
            _bonusesHandler = bonusesHandler;
            _scoreManager = scoreManager;
            _snake = snake;
        }

        public void MainProcess()
        {
            Console.CursorVisible = false;

            ScreenRenderer.StartingScreen();

            GameLoop();

            FileManager.SaveHighScore(GameConfig.Player, _scoreManager.Score);
            ScreenRenderer.GameOverScreen(_scoreManager);
        }

        private void GameLoop()
        {
            EnableTimers();

            // Initial apple spawn and score render
            _bonusesHandler.Add(
                Spawner.Spawn(
                    _snake.Body, Factory.CreateApple()
                    ));

            _scoreManager.Render();

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

            DisableTimers();
        }

        private void EnableTimers()
        {
            // Timers for Bonuses
            _timers.Add(new Timer ((e) => TimerCallback(Factory.CreateDollar), null, 1, 20000));
            _timers.Add(new Timer((e) => TimerCallback(Factory.CreateCross), null, 5000, 10000));
        }

        private void TimerCallback(Func<IBonus> func)
        {
            _bonusesHandler.Add(
                Spawner.Spawn(
                    _snake.Body, func()
                    ));
        }

        private void DisableTimers()
        {
            _timers.ForEach((t) => t.Dispose());
        }

        private void SetLegalDirection()
        {
            if (Enum.TryParse<Directions>(_keyPressed, out var legalDirection))
            {
                _direction = legalDirection;
            }
        }

        private void OnAction()
        {
            while (Console.KeyAvailable == false)
            {
                _snake.UpdateBodyPosition();

                try
                {
                    _snake.Move(_direction);
                    _scoreManager.CheckScoreUnderZero();
                }
                catch (GameEndException)
                {
                    snakeIsAlive = false;
                    break;
                }

                if (_bonusesHandler.SnakeOnBonus(_snake.Head))
                {
                    _bonusesHandler.Handle(_snake, _scoreManager);

                    _diffilcultyHandler.CheckToRaiseLevel(_scoreManager.Score);

                    _scoreManager.Render();
                }

                _snake.Render();

                Thread.Sleep(_diffilcultyHandler.Miliseconds);
            }

            if (snakeIsAlive)
            {
                _keyPressed = Console.ReadKey(true).Key.ToString();
            }
        }
    }
}
