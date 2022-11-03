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
        private static DiffilcultyHandler _instance;

        private const int LevelBreakPoint = 5;
        private const int LevelSpeedModifier = 5;

        private int _level = 0;

        public static DiffilcultyHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DiffilcultyHandler();
                }

                return _instance;
            }
        }

        public int Miliseconds { get; set; } = 75;

        private DiffilcultyHandler()
        {
        }

        public void CheckToChangeLevel(int currentScore)
        {
            if (GetFirstDigit(currentScore) > _level)
            {
                if (Miliseconds > LevelBreakPoint)
                {
                    Miliseconds -= LevelSpeedModifier;
                    _level++;
                }
            }
            else if (GetFirstDigit(currentScore) < _level)
            {
                Miliseconds += LevelSpeedModifier;
                _level--;
            }
        }

        public void EnableDiscoSpeed()
        {
            Miliseconds /= 2;
        }

        public void DisableDiscoSpeed()
        {
            Miliseconds *= 2;
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
