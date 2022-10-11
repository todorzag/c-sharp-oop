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
        private int _level = 0;
        public int Miliseconds { get; set; } = 75;

        public DiffilcultyHandler()
        {
        }

        public void CheckToRaiseLevel(int currentScore)
        {
            if (GetFirstDigit(currentScore) > _level)
            {
                if (Miliseconds > 5)
                {
                    Miliseconds -= 5;
                    _level++;
                }
            }
        }

        public void CheckToDecreaseLevel(int currentScore, int previousScore)
        {
            if (GetFirstDigit(currentScore) < GetFirstDigit(previousScore))
            {
                Miliseconds += 5;
                _level--;
            }
        }

        private int GetFirstDigit(int value)
        {
            if (value < 10)
            {
                return 0;
            }

            value = (int)(value / Math.Pow(10, (int)Math.Floor(Math.Log10(value))));
            return value;
        }
    }
}
