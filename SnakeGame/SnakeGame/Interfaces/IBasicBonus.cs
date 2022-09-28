using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
     public interface IBasicBonus : IPoint
     {
        string Symbol { get; }
        int ScoreValue { get; }
     }
}
