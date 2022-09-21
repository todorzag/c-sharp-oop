namespace SnakeGame.Interfaces
{
    internal interface IDiffilcultyHandler
    {
        int Miliseconds { get; set; }

        void CheckToRaiseLevel(int score);
    }
}