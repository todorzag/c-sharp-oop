using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public interface IBonusesHandler
    {
        void Add(IBonus bonus);
        void Handle(ISnake snake, IScoreManager scoreManager);
        bool OnBonus(IPoint snakeHead);
    }
}