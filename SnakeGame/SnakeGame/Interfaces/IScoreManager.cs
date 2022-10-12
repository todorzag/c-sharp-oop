namespace SnakeGame.Interfaces
{
    public interface IScoreManager : IRenderable
    {
        int CurrentScore { get; }
        int PreviousScore { get; }

        void Render();
        void Set(List<IPoint> snakeBody);
        bool CheckScoreUnderZero();
    }
}