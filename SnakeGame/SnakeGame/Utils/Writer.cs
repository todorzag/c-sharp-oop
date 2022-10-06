using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    // console writer, file writer, add writer for standard messages
    internal class Writer
    {
        private static string _filePath 
            = @"C:\Users\todor.zagorov\source\repos\c-sharp-oop\SnakeGame\SnakeGame\HighScores.txt";

        public static void ConsoleWriteAt(int y, int x, string str)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(str);
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
