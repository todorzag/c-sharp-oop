using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IBonus : IPoint, IConsumable, IRenderable
    {
        string Symbol { get; }
        int ScoreValue { get; }
    }
}
