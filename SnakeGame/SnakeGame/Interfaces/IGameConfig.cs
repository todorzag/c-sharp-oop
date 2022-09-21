using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    internal interface IGameConfig
    {
        (IPlayer, bool, int) GetDataFromInput();
    }
}
