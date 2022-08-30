using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class GameBoard
    {
        public string[,] Board { get; private set; }
        public bool Walls { get; private set; }

        public GameBoard(bool walls)
        {
            Walls = walls;
            Board = CreateBoard();
        }

        public string[,] CreateBoard()
        {
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;

            string[,] board = new string[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    board[row, col] = " ";
                }
            }

            return board;
        }

        public void RenderBoard()
        {
            for (int x = 0; x < Board.GetLength(0); x++)
            {
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    Console.Write(Board[x, y]);
                }
            }
        }
    }
}
