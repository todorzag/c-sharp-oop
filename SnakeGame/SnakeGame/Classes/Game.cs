using SnakeGame.Classes.Strategies;
using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System.Xml.Linq;

namespace SnakeGame.Classes
{
    public class Game : IGame
    {
        public bool snakeIsAlive = true;

        private IScoreManager _scoreManager;
        private IDiffilcultyHandler _diffilcultyHandler;
        private IFoodHandler _foodHandler;
        private ISnake _snake;

        private List<Timer> _timers =
            new List<Timer>();

        private string _keyPressed;

        public Game(
            IDiffilcultyHandler diffilcultyHandler,
            IFoodHandler foodHandler,
            IScoreManager scoreManager,
            ISnake snake)
        {
            _diffilcultyHandler = diffilcultyHandler;
            _foodHandler = foodHandler;
            _scoreManager = scoreManager;
            _snake = snake;
        }

        public void MainProcess()
        {
            Console.CursorVisible = false;

            ScreenRenderer.StartingScreen();

            GameLoop();

            Writer.FileWrite(GameConfig.Player, _scoreManager.Score);
            ScreenRenderer.GameOverScreen(_scoreManager);
        }

        private void GameLoop()
        {
            // Initial apple spawn and score render
            EnableTimers();
            Spawner.Spawn(_snake.Body, Factory.CreateApple());
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
            _timers.Add(new Timer((e) 
                => TimerCallback(Factory.CreateSwitch), null, 7000, 7000));

            _timers.Add(new Timer((e) 
                => TimerCallback(Factory.CreateCross), null, 5000, 5000));
        }

        private void TimerCallback(Func<IFood> create)
        {
            Spawner.Spawn(_snake.Body, create());
        }

        private void DisableTimers()
        {
            _timers.ForEach((t) => t.Dispose());
        }

        private void SetLegalDirection()
        {
            if (Enum.TryParse<Directions>(_keyPressed, out var legalDirection))
            {
                _snake.Direction = legalDirection;
            }
        }

        private void OnAction()
        {
            while (Console.KeyAvailable == false)
            {
                _snake.UpdateBodyPosition();

                try
                {
                    _snake.Move();
                    _scoreManager.CheckScoreUnderZero();
                }
                catch (GameEndException)
                {
                    snakeIsAlive = false;
                    break;
                }

                _snake.Render();

                if (_foodHandler.SnakeOnFood(_snake.Head))
                {
                    _foodHandler.Handle(_snake, _scoreManager);

                    _diffilcultyHandler.CheckToRaiseLevel(_scoreManager.Score);

                    _scoreManager.Set(_snake.Body);
                    _scoreManager.Render();
                }

                Thread.Sleep(_diffilcultyHandler.Miliseconds);
            }

            if (snakeIsAlive)
            {
                _keyPressed = Console.ReadKey(true).Key.ToString();
            }
        }
    }
}
