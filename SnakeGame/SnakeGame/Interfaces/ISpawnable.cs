using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
     public interface ISpawnable : IPoint
     {
        string Symbol { get; }
     }
}
