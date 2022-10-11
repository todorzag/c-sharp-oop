using SnakeGame.Classes.Strategies;
using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System.Xml.Linq;

namespace SnakeGame.Classes
{
    public class Game : IGame
    {

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

            Writer.FileWrite(GameConfig.Player, _scoreManager.CurrentScore);
            ScreenRenderer.GameOverScreen(_scoreManager);
        }

        private void GameLoop()
        {
            // Initial apple spawn and score render
            EnableTimers();
            Spawner.Spawn(_snake.Body, Factory.CreateApple());
            _scoreManager.Render();

            while (_snake.IsAlive)
            {
                if (_keyPressed == "Escape")
                {
                    _snake.IsAlive = false;
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
                => TimerCallback(Factory.CreateSwitch), null, 10000, 10000));

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

                _snake.Move();
                _scoreManager.CheckScoreUnderZero(_snake);

                _snake.Render();

                if (_foodHandler.SnakeOnFood(_snake.Head))
                {
                    _foodHandler.Handle(
                        _snake,
                        _scoreManager);

                    _scoreManager.Set(_snake.Body, _diffilcultyHandler);
                    _scoreManager.Render();

                    _diffilcultyHandler
                        .CheckToRaiseLevel(
                        _scoreManager.CurrentScore);

                }

                if (_snake.IsAlive == false)
                {
                    break;
                }

                Thread.Sleep(_diffilcultyHandler.Miliseconds);
            }

            if (_snake.IsAlive)
            {
                _keyPressed = Console.ReadKey(true).Key.ToString();
            }
        }
    }
}
