using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class Writer
    {
        private static bool _isRendering = false;

        private static string _filePath
            = @"C:\Users\todor.zagorov\source\repos\c-sharp-oop\SnakeGame\SnakeGame\HighScores.txt";

        public static void ConsoleWriteAt(int y, int x, string str)
        {
            if (_isRendering == false)
            {
                _isRendering = true;
                Console.SetCursorPosition(y, x);
                Console.Write(str);
                _isRendering = false;
            }
            else
            {
                ConsoleWriteAt(y, x, str);
            }
        }

        public static void FileWrite(IPlayer player, int score)
        {
            File.AppendAllText(_filePath,
                $"{player.UserName} - {score} - {DateTime.Now}\r\n");
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
