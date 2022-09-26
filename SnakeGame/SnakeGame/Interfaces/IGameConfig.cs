using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IGameConfig
    {
        IPlayer Player { get; set; }
        bool HasWalls { get; set; }
        int SnakeLength { get; set; }
    }
}
