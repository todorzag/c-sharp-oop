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

        private IGameConfig _config;

        private string _keyPressed;
        private Directions _direction = Directions.RightArrow;

        public Game(
            IGameConfig gameConfig, 
            IDiffilcultyHandler diffilcultyHandler,
            IBonusesHandler bonusesHandler,
            IScoreManager scoreManager,
            ISnake snake)
        {
            _config = gameConfig;
            _diffilcultyHandler = diffilcultyHandler;
            _bonusesHandler = bonusesHandler;
            _scoreManager = scoreManager;
            _snake = snake;
        }

        public void MainProcess()
        {
            Console.CursorVisible = false;

            ScreenRenderer.StartingScreen();

            // Initial apple spawn
            _bonusesHandler.Add(
                Spawner.Spawn(
                    _snake.Body, Factory.CreateApple()
                    ));

            GameLoop();

            FileManager.SaveHighScore(_config.Player, _scoreManager.Score);
            ScreenRenderer.GameOverScreen(_scoreManager);
        }

        private void GameLoop()
        {
            // Timer for Dollar spawnable
            Timer dollarTimer = new(DollarTimerCallback, null, 0, 20000);
            Timer crossTimer = new(CrossTimerCallback, null, 5000, 10000);

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

            dollarTimer.Dispose();
            crossTimer.Dispose();
        }

        private void DollarTimerCallback(object o)
        {
            _bonusesHandler.Add(
                Spawner.Spawn(
                    _snake.Body, Factory.CreateDollar()
                    ));
        }

        private void CrossTimerCallback(object o)
        {
            _bonusesHandler.Add(
                Spawner.Spawn(
                    _snake.Body, Factory.CreateCross()
                    ));
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

                if (_bonusesHandler.OnBonus(_snake.Head))
                {
                    _bonusesHandler.Handle(_snake, _scoreManager);

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
    }
}
