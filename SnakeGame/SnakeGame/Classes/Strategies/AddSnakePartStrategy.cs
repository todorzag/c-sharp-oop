using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes.Strategies
{
    public class AddSnakePartStrategy : IConsumable
    {
        private static AddSnakePartStrategy instance;

        public static AddSnakePartStrategy GetStrategy
        {
            get 
            { 
                if (instance == null)
                {
                    instance = new AddSnakePartStrategy();
                }

                return instance;
            }
        }

        private AddSnakePartStrategy() { }

        public void PerformConsume(ISnake snake, int scoreValue)
        {
            for (int i = 0; i < scoreValue; i++)
            {
                snake.AddPart();
            }   
        }
    }
}
