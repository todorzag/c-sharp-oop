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
        public bool isEaten { get; set; } = true;

        public void SpawnApple(string[,] board)
        {
            while (true)
            {
                // -2 because of board border
                int x = Random.Next(1, board.GetLength(0) - 2);
                int y = Random.Next(1, board.GetLength(1) - 2);

                if (board[x, y] == " ")
                {
                    board[x, y] = "@";
                    isEaten = false;
                    break;
                }
            }
        }
    }
}
