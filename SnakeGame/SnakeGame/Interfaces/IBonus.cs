using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IFood : IPoint, IStrategy, IRenderable
    {
        string Symbol { get; }
    }
}
