using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class GameConfig
    {
        public static IPlayer Player { get; set; }
        public static bool HasWalls { get; set; }
        public static int InitalSnakeLength { get; set; }

        public static void SetConfigData(
            IPlayer player,
            bool hasWalls,
            int snakeLength)
        {
            Player = player;
            HasWalls = hasWalls;
            InitalSnakeLength = snakeLength;
        }
    }
}
