namespace SnakeGame.Interfaces
{
    public interface IScoreManager : IRenderable
    {
        int Score { get; set; }

        void Render();
        void Set(List<IPoint> snakeBody);
        void CheckScoreUnderZero();
    }
}