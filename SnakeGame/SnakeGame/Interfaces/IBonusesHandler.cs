namespace SnakeGame.Interfaces
{
    public interface IBonusesHandler : IRenderable
    {
        void Add(IBonus bonus);
        void Handle(ISnake snake, IScoreManager scoreManager);
        bool SnakeOnBonus(IPoint snakeHead);
        bool OnBonus(IBonus bonus);
    }
}