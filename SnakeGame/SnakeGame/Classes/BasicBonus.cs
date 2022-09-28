﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    public abstract class BasicBonus : Point, IBasicBonus
    {
        protected BasicBonus(int x, int y) : base(x, y)
        {
        }

        public abstract string Symbol { get; }

        public abstract int ScoreValue { get; }

    }
}