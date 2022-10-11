namespace SnakeGame.Interfaces
{
    public interface IDiffilcultyHandler
    {
        int Miliseconds { get; set; }

        void CheckToDecreaseLevel(int currentScore, int previousScore);
        void CheckToRaiseLevel(int score);
    }
}