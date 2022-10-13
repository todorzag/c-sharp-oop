using SnakeGame.Classes.Strategies;
using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System.ComponentModel.DataAnnotations;
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
            // Initial apple spawn and renders
            EnableTimers();
            Spawner.Spawn(_snake.Body, Factory.CreateApple());
            _scoreManager.Render();

            while (_snake.IsAlive)
            {
                SetLegalDirection();

                OnAction();

                if (_keyPressed == "Escape")
                {
                    _snake.IsAlive = false;
                    break;
                }
            }

            DisableTimers();
        }

        private void EnableTimers()
        {
            var switchTime = 10000;
            var crossTime = 5000;

            _timers.Add(new Timer((e)
                => TimerCallback(Factory.CreateSwitch), null, switchTime, switchTime));

            _timers.Add(new Timer((e)
                => TimerCallback(Factory.CreateCross), null, crossTime, crossTime));
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
            while (Console.KeyAvailable == false && _snake.IsAlive)
            {
                _snake.UpdateBodyPosition();
                _snake.Move();
                _snake.Render();

                if (_foodHandler.SnakeOnFood(_snake.Head))
                {
                    _foodHandler.Handle(
                        _snake);

                    _scoreManager.Set(_snake.Body);
                    _scoreManager.Render();

                    _diffilcultyHandler.
                        CheckToChangeLevel(_snake.CurrentLength);
                }

                // Snake max length and score under zero checks
                if (_snake.CurrentLength < 0
                    || SnakeLengthValidator.ValidateMaxLength(_snake.Body.Count))
                {
                    _snake.IsAlive = false;
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
