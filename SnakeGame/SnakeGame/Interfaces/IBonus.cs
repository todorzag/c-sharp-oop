using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IBonus : IPoint, IStrategy, IRenderable
    {
        string Symbol { get; }
    }
}
