using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class DiffilcultyHandler : IDiffilcultyHandler
    {
        private int _level = 1;

        public int Miliseconds { get; set; } = 75;

        public DiffilcultyHandler()
        {
        }

        // bug from 5 to 4 and back to 5
        public void CheckToRaiseLevel(int score)
        {
            if (score % 5 == 0 && score != 0)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            if (Miliseconds > 10)
            {
                Miliseconds -= 5;
            }
            
            _level++;
        }
    }
}
