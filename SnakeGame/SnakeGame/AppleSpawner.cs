using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class AppleSpawner
    {
        public static Random Random = new Random();

        public void SpawnApple(string[,] board)
        {
            while (true)
            {
                int x = Random.Next(1, board.GetLength(0) - 1);
                int y = Random.Next(1, board.GetLength(1) - 1);

                if (board[x, y] == " ")
                {
                    board[x, y] = "@";
                    break;
                }
            }
        }
    }
}
