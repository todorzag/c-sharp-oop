using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class BonusesHandler : IBonusesHandler
    {
        private BonusesHandler() { }

        private static List<IBonus> _bonuses =
            new List<IBonus>();

        private static BonusesHandler instance;

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

            bonus.PerformConsume(snake);
        }

        public void Add(IBonus bonus)
        {
            _bonuses.Add(bonus);
        }

        public bool SnakeOnBonus(IPoint snakeHead)
        {
            return _bonuses.Any((b) => b.EqualsPosition(snakeHead));
        }

        public bool OnBonus(IBonus bonus)
        {
            return _bonuses.Any((b) => b.EqualsPosition(bonus));
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
