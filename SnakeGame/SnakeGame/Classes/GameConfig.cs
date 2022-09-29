using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    // singleton
    internal class GameConfig : IGameConfig
    {
        public IPlayer Player { get ; set; }
        public bool HasWalls { get; set; }
        public int InitalSnakeLength { get; set; }

        public GameConfig (IPlayer player, bool hasWalls, int snakeLength)
        {
            Player = player;
            HasWalls = hasWalls;
            InitalSnakeLength = snakeLength;
        }
    }
}
