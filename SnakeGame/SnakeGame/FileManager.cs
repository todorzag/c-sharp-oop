namespace SnakeGame
{
    public class FileManager
    {
        private static string _filePath 
            = @"C:\Users\todor.zagorov\source\repos\c-sharp-oop\SnakeGame\SnakeGame\HighScores.txt";

        public static void SaveHighScore(string user, int score)
        {
            File.AppendAllText(_filePath, 
                $"{user} - {score} - {DateTime.Now}\r\n");
        }
    }
}
