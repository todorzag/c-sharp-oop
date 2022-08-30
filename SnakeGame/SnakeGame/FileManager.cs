using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class FileManager
    {
        private static string _filePath = @"C:\Users\todor.zagorov\source\repos\c-sharp-oop\SnakeGame\SnakeGame\HighScores.txt";

        public static void SaveHighScore(string user, int score)
        {
            File.AppendAllText(_filePath, $"\r\n{user} - {score} - {DateTime.Now}");
        }
    }
}
