using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IGameConfig
    {
        static IPlayer Player { get; set; }
        static bool HasWalls { get; set; }
        static int InitalSnakeLength { get; set; }

        void SetConfigData(IPlayer player, bool hasWalls, int snakeLength);
    }
}
