using SnakeGame.Classes;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class Spawner
    {
        private static Random _random = new Random();

        public static void Spawn(List<IPoint> snakeBody, IFood food)
        {
            IFoodHandler foodHandler = Factory.GetFoodHandler();
            SetRandomPosition(snakeBody, food);

            foodHandler.Add(food);
            food.Render();
        }

        private static IFood SetRandomPosition(
            List<IPoint> snakeBody,
            IFood food)
        {
            while (true)
            {
                int x = _random.Next(1, Console.WindowHeight - 1);
                int y = _random.Next(1, Console.WindowWidth - 1);

                IFoodHandler foodHandler = Factory.GetFoodHandler();
                bool outsideOfScoreRange = x > 0 && y > 10;

                food.Position = (x, y);

                if ((snakeBody.Any(x => x.EqualsPosition(food)) == false)
                    && foodHandler.OnFood(food) == false
                    && outsideOfScoreRange)
                {
                    return food;
                }
            }
        }
    }
}