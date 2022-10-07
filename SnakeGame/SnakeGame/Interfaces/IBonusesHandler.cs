namespace SnakeGame.Interfaces
{
    public interface IFoodHandler : IRenderable
    {
        void Add(IFood food);
        void Handle(ISnake snake, IScoreManager scoreManager);
        bool SnakeOnFood(IPoint snakeHead);
        bool OnFood(IFood food);
    }
}