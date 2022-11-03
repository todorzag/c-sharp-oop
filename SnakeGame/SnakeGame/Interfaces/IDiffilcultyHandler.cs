namespace SnakeGame.Interfaces
{
    public interface IDiffilcultyHandler
    {
        int Miliseconds { get; set; }

        void CheckToChangeLevel(int currentScore);
        void EnableDiscoSpeed();
        void DisableDiscoSpeed();
    }
}