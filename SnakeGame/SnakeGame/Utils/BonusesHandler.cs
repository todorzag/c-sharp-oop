using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    public class BonusesHandler : IBonusesHandler
    {
        private BonusesHandler() { }

        private static BonusesHandler instance = null;

        private static List<IBonus> _bonuses =
            new List<IBonus>();
        public static BonusesHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BonusesHandler();
                }

                return instance;
            }
        }

        public void Handle(ISnake snake, IScoreManager scoreManager)
        {
            IBonus bonus = GetBonus(snake.Head);

            Remove(bonus);
            scoreManager.Add(bonus.ScoreValue);
            bonus.Consume(snake);
        }

        public void Add(IBonus bonus)
        {
            _bonuses.Add(bonus);
        }

        public bool OnBonus(IPoint snakeHead)
        {
            return _bonuses.Any((s) => s.EqualsPosition(snakeHead));
        }

        private void Remove(IBonus bonus)
        {
            _bonuses.Remove(bonus);
        }

        private IBonus GetBonus(IPoint snakeHead)
        {
            return _bonuses.Find((s) => s.EqualsPosition(snakeHead));
        }
    }
}
