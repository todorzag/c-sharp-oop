namespace SnakeGame.Interfaces
{
    public interface IScoreManager : IRenderable
    {
        int CurrentScore { get; set; }

        void Render();
        void Set(List<IPoint> snakeBody, IDiffilcultyHandler diffilcultyHandler);
        void CheckScoreUnderZero(ISnake snake);
    }
}