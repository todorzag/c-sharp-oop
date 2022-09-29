namespace SnakeGame.Interfaces
{
    public interface IDiffilcultyHandler
    {
        int Miliseconds { get; set; }

        void CheckToRaiseLevel(int score);
    }
}