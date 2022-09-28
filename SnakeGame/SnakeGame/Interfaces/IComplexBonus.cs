using SnakeGame.Classes;

namespace SnakeGame.Interfaces
{
    public interface IComplexBonus : IBasicBonus
    {
        void OnDevour(ISnake snake);
    }
}