using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class DiffilcultyHandler : IDiffilcultyHandler
    {
        private int _miliseconds = 75;
        private int _level = 1;

        public int Miliseconds
        {
            get => _miliseconds;
        }

        public void CheckToRaiseLevel(int score)
        {
            if (score % 10 == 0 && score != 0)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            if (_miliseconds > 10)
            {
                _miliseconds -= 5;
            }
            
            _level++;
        }
    }
}
