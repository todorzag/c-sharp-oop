using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    internal class GameConfig : IGameConfig
    {
        public IPlayer Player { get ; set; }
        public bool HasWalls { get; set; }
        public int SnakeLength { get; set; }

        public GameConfig (IPlayer player, bool hasWalls, int snakeLength)
        {
            Player = player;
            HasWalls = hasWalls;
            SnakeLength = snakeLength;
        }
    }
}
