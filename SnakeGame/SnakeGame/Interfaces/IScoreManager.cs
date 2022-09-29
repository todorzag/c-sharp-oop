namespace SnakeGame.Interfaces
{
    public interface IScoreManager
    {
        int Score { get; set; }

        void Add(int n);

        void Render();
    }
}