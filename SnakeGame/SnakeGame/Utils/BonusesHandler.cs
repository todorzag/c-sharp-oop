using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class FoodHandler : IFoodHandler
    {
        private FoodHandler() { }

        private static List<IFood> _foods =
            new List<IFood>();

        private static FoodHandler instance;

        public static FoodHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodHandler();
                }

                return instance;
            }
        }

        public void Handle(ISnake snake, IScoreManager scoreManager)
        {
            IFood food = GetFood(snake.Head);

            Remove(food);

            food.PerformConsume(snake);
        }

        public void Add(IFood food)
        {
            _foods.Add(food);
        }

        public bool SnakeOnFood(IPoint snakeHead)
        {
            return _foods.Any((b) => b.EqualsPosition(snakeHead));
        }

        public bool OnFood(IFood food)
        {
            return _foods.Any((b) => b.EqualsPosition(food));
        }

        // try observer pattern?
        public void Render()
        {
            for (int i = 0; i < _foods.Count; i++)
            {
                _foods[i].Render();
            }
        }

        private void Remove(IFood food)
        {
            _foods.Remove(food);
        }

        private IFood GetFood(IPoint snakeHead)
        {
            return _foods.Find((s) => s.EqualsPosition(snakeHead));
        }
    }
}
