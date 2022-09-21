using SnakeGame.Interfaces;

namespace SnakeGame.Utils
{
    public class FileManager
    {
        private static string _filePath
            = @"C:\Users\todor.zagorov\source\repos\c-sharp-oop\SnakeGame\SnakeGame\HighScores.txt";

        public static void SaveHighScore(IPlayer player, int score)
        {
            File.AppendAllText(_filePath,
                $"{player.UserName} - {score} - {DateTime.Now}\r\n");
        }
    }
}
