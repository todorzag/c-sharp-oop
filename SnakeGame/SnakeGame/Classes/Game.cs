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
        private IBonusesHandler _bonusesHandler;
        private ISnake _snake;

        private List<Timer> _timers = new List<Timer>();

        private string _keyPressed;

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

            Writer.FileWrite(GameConfig.Player, _scoreManager.Score);
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
            // try with tasks
            // Timers for Bonuses
            Task t1 = new Task(() =>
                _timers.Add(new Timer((e) => TimerCallback(Factory.CreateSwitch()), null, 5000, 7000)));

            t1.Start();

            Task t2 = new Task(() =>
                _timers.Add(new Timer((e) => TimerCallback(Factory.CreateCross()), null, 1000, 4000)));

            t2.Start();
        }

        private void TimerCallback(IBonus bonus)
        {
            _bonusesHandler.Add(
                Spawner.Spawn(
                    _snake.Body, bonus
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

                if (_bonusesHandler.SnakeOnBonus(_snake.Head))
                {
                    _bonusesHandler.Handle(_snake, _scoreManager);

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
