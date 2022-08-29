using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class GameBoard
    {
        public int Width { get; }
        public int Height { get; }
        public string[,] Board { get; }

        public GameBoard(int height, int width)
        {
            Board = CreateBoard(height + 2, width + 2);
        }

        private string[,] CreateBoard(int height, int width)
        {
            string[,] board = new string[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    board[row, col] = " ";
                }
            }

            for (int x = 0; x < width; x++)
            {
                board[0, x] = "-";
            }

            for (int x = 0; x < width; x++)
            {
                board[height - 1, x] = "-";
            }

            for (int y = 1; y < height - 1; y++)
            {
                board[y, 0] = "|";
            }

            for (int y = 1; y < height - 1; y++)
            {
                board[y, width - 1] = "|";
            }

            return board;
        }

        public void RenderBoard()
        {
            Console.WriteLine();

            for (int x = 0; x < Board.GetLength(0); x++)
            {
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    Console.Write(Board[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
